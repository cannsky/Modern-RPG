using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SplashScreenManager : MonoBehaviour
{
    [SerializeField] bool logoAppearMoreSmoothly;
    [SerializeField] CanvasGroup logoBlackout;
    [SerializeField] Image logo;
    [SerializeField] CanvasGroup parmaText;
    [SerializeField] CanvasGroup gamesText;
    [SerializeField] CanvasGroup smallBlackout;
    [SerializeField] CanvasGroup bigBlackout;
    [SerializeField] int framePerSecond=60;

    [SerializeField] float blackScreenDuration = 0.2f;

    [SerializeField] float textDullDuration = 0.6f;
    [SerializeField] float waitBetweenTexts = 0.4f;

    [SerializeField] bool useSameDurationsForTextAndLogo;
    [SerializeField] float logoDullDuration = 1.6f;
    [SerializeField] bool colorReductionAtOnce;

    [SerializeField] float waitBeforeBlackout = 0.3f;
    [SerializeField] float blackoutTime = 0.5f;
    [SerializeField] [Range(0,1)] float secondBlackoutRatio=0.6f;
    [SerializeField] float finalWaitBeforeLoad = 0.1f;

    int totalFrames = 0;
    float delta = 0;
    float oneFrame;
    (bool logoDone,bool textDone) conditions = (false,false);
    bool blackoutComplete;
    WaitForSeconds frameLength;
    private void Start()
    {
        parmaText.alpha = 0;
        gamesText.alpha = 0;
        logoBlackout.alpha = 1;
        logo.color = new Color(0, 0, 0,logoAppearMoreSmoothly ? 0 : 1);
        oneFrame = OneOver(framePerSecond);
        frameLength = new WaitForSeconds(oneFrame);

        StartCoroutine(MainCoroutine());
    }
    IEnumerator MainCoroutine()
    {
        yield return new WaitForSeconds(blackScreenDuration);

        StartCoroutine(AnimateText());
        StartCoroutine(AnimateLogo());

        yield return new WaitUntil(() => conditions == (true, true));

        yield return new WaitForSeconds(waitBeforeBlackout);

        StartCoroutine(AnimateBlackout());

        yield return new WaitUntil(() => blackoutComplete);

        yield return new WaitForSeconds(finalWaitBeforeLoad);

        SceneManager.LoadScene(2);
    }

    IEnumerator AnimateText()
    {
        float totalFrames = CalculateTotalFrames(textDullDuration);
        float delta = OneOver(totalFrames);

        for (int i = 0; i < totalFrames; i++)
        {
            parmaText.alpha += delta;
            yield return frameLength;
        }

        yield return new WaitForSeconds(waitBetweenTexts);

        for (int i = 0; i < totalFrames; i++)
        {
            gamesText.alpha += delta;
            yield return frameLength;
        }

        conditions = (conditions.logoDone, true);
    }

    IEnumerator AnimateLogo()
    {
        int totalFrames = CalculateTotalFrames((useSameDurationsForTextAndLogo ? 2 * textDullDuration + waitBetweenTexts : logoDullDuration));
        float delta = OneOver(totalFrames);
        
        if (colorReductionAtOnce)
        {
            for (int i = 0; i < totalFrames; i++)
            {
                logo.color = new Color(logo.color.r + delta, logo.color.g + delta, logo.color.b + delta,GetAlpha());
                logoBlackout.alpha -= delta;
                yield return frameLength;
            }
        }
        else
        {
            WaitForSeconds oneThirdFrameLength = new WaitForSeconds(oneFrame / 3);
            int threeTimesTotalFrames = 3 * totalFrames;

            for (int i = 0; i < threeTimesTotalFrames; i++)
            {
                switch (i%3)
                {
                    case 0:
                        logo.color = new Color(logo.color.r + delta, logo.color.g, logo.color.b, GetAlpha());
                        break;
                    case 1:
                        logo.color = new Color(logo.color.r, logo.color.g + delta, logo.color.b, GetAlpha());
                        break;
                    case 2:
                        logo.color = new Color(logo.color.r, logo.color.g, logo.color.b + delta, GetAlpha());
                        break;
                }

                logoBlackout.alpha -= delta;

                yield return oneThirdFrameLength;
            }
        }

        conditions = (true, conditions.textDone);

        float GetAlpha() => logoAppearMoreSmoothly ? logo.color.a + delta : logo.color.a;
    }

    IEnumerator AnimateBlackout()
    {
        yield return new WaitForSeconds(waitBeforeBlackout);

        totalFrames = CalculateTotalFrames(blackoutTime);
        delta = OneOver(totalFrames);

        float delta2 = OneOver(secondBlackoutRatio * totalFrames);

        for (int i = 0; i < totalFrames; i++)
        {
            smallBlackout.alpha += delta;
            if ((i + 1) / (float)totalFrames >= secondBlackoutRatio)
                bigBlackout.alpha += delta2;
            yield return frameLength;
        }

        blackoutComplete = true;
    }
    int CalculateTotalFrames(float duration) => (int)(framePerSecond * duration);
    float OneOver(float number) => 1f / number;
}