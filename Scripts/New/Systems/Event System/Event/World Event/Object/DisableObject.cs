using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Object Event/Disable Object", order = 2)]
public class DisableObject : WorldEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectTargetList)
            foreach (GameObject gameObject in base.effectedGameObjectList) if (!UpdateGameObjectVisibility(gameObject)) return false;
        if (base.isEffectTarget)
            if (!UpdateGameObjectVisibility(base.gameObjectTarget)) return false;
        if (base.isEffectItSelf)
            if (!UpdateGameObjectVisibility(base.gameObjectSelf)) return false;
        return true;
    }

    public bool UpdateGameObjectVisibility(GameObject gameObject)
    {
        gameObject.SetActive(false);
        return !gameObject.activeSelf;
    }
}
