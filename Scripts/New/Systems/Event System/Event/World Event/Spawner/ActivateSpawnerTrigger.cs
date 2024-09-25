using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Game Event/World Event/Spawner Event/Activate Spawner Trigger", order = 2)]
public class ActivateSpawnerTrigger : WorldEvent
{
    public int level = 1;
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!UpdateSpawnerTrigger(base.gameObjectSelf.transform.parent.parent.GetChild(1).GetChild(level - 1).gameObject)) return false;
        return true;
    }

    public bool UpdateSpawnerTrigger(GameObject gameObject)
    {
        gameObject.SetActive(true);
        return true;
    }
}
