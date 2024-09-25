using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Gate Event/Rotate Gate Door", order = 1)]
public class RotateGateDoor : WorldEvent
{
    public bool isReversed;

    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!Rotate(base.gameObjectSelf.transform.parent.gameObject)) return false;
        return true;
    }

    public bool Rotate(GameObject gameObject)
    {
        Transform rotatePoint = isReversed ? gameObject.transform.GetChild(0) : gameObject.transform.GetChild(1);
        IEnumerator coroutine = SmoothRotate(isReversed ? gameObject.transform.GetChild(2).gameObject : 
            gameObject.transform.GetChild(3).gameObject, rotatePoint);
        EnumerationController.Instance.HandleEnumeration(coroutine);
        return true;
    }

    public IEnumerator SmoothRotate(GameObject gameObject, Transform rotatePoint)
    {
        Debug.Log(gameObject.name);
        if (!isReversed)
        {
            while (!(Mathf.Abs(gameObject.transform.localEulerAngles.y) >= 90f))
            {
                gameObject.transform.RotateAround(rotatePoint.position, Vector3.up, 12 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (!(Mathf.Abs(gameObject.transform.localEulerAngles.y) >= 360f))
            {
                if (gameObject.transform.localEulerAngles.y <= 270) break;
                gameObject.transform.RotateAround(rotatePoint.position, Vector3.up, -12 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
