using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Chest Event/Rotate Chest Lid", order = 1)]
public class RotateChestLid : WorldEvent
{

    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!Rotate(base.gameObjectSelf.transform.parent.parent.gameObject)) return false;
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
        while (!(Mathf.Abs(gameObject.transform.localEulerAngles.x) >= 360f))
        {
            if (gameObject.transform.localEulerAngles.x <= 280) break;
            gameObject.transform.RotateAround(rotatePoint.position, Vector3.back, -20 * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
