using UnityEngine;
using System.Collections;
using System;

public class FrameManager : MonoBehaviour
{
    static FrameManager instance;
    public static FrameManager Instance { get => instance; }

    [SerializeField] bool fpsLimit = false;
    [SerializeField] int desiredFPS = 60;

    int frames;
    public int FPS { get => frames; }

    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);

        Application.targetFrameRate = -1;
        QualitySettings.vSyncCount = 0;
    }

    void Update()
    {
        if (fpsLimit) LimitFrames();
        CountFrames();
    }

    void LimitFrames()
    {
        long lastTicks = DateTime.Now.Ticks;
        long currentTicks = lastTicks;
        float delay = 1f / desiredFPS;
        float elapsedTime;

        if (desiredFPS <= 0)
            return;

        while (true)
        {
            currentTicks = DateTime.Now.Ticks;
            elapsedTime = (float)TimeSpan.FromTicks(currentTicks - lastTicks).TotalSeconds;
            if (elapsedTime >= delay)
            {
                break;
            }
        }
    }

    void CountFrames() => frames = (int)Mathf.Round(1f / Time.deltaTime);
}