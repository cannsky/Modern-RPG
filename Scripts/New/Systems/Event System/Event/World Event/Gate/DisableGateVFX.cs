using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Gate Event/Disable Gate VFX", order = 2)]
public class DisableGateVFX : WorldEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!UpdateGameObjectVisibility(base.gameObjectSelf.transform.parent.GetChild(4).gameObject)) return false;
        return true;
    }

    public bool UpdateGameObjectVisibility(GameObject gameObject)
    {
        gameObject.SetActive(false);
        return !gameObject.activeSelf;
    }
}
