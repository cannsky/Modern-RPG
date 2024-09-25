using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Object Event/Rotate Around Object", order = 1)]
public class RotateAroundObject : WorldEvent
{
    public bool isReversed;

    public override bool HandleEvent()
    {
        if (base.isEffectTargetList)
            foreach (GameObject gameObject in base.effectedGameObjectList) if (!Rotate(gameObject)) return false;
        if (base.isEffectTarget)
            if (!Rotate(base.gameObjectTarget)) return false;
        if (base.isEffectItSelf)
            if (!Rotate(base.gameObjectSelf)) return false;
        return true;
    }

    public bool Rotate(GameObject gameObject)
    {
        Transform rotatePoint = gameObject.transform.GetChild(0);
        IEnumerator coroutine = SmoothRotate(gameObject, rotatePoint);
        EnumerationController.Instance.HandleEnumeration(coroutine);
        return true;
    }

    public IEnumerator SmoothRotate(GameObject gameObject, Transform rotatePoint)
    {
        if (!isReversed)
        {
            while (!(Mathf.Abs(gameObject.transform.localEulerAngles.y) >= 90f))
            {
                gameObject.transform.RotateAround(rotatePoint.position, Vector3.up, 20 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
        else
        {
            while (!(Mathf.Abs(gameObject.transform.localEulerAngles.y) >= 360f))
            {
                if (gameObject.transform.localEulerAngles.y <= 270) break;
                gameObject.transform.RotateAround(rotatePoint.position, Vector3.up, -20 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
        }
    }

}
