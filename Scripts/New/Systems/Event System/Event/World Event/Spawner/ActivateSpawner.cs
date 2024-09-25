using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(menuName = "Game Event/World Event/Spawner Event/Activate Spawner", order = 1)]
public class ActivateSpawner : WorldEvent
{
    public int level = 1;
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!UpdateSpawner(base.gameObjectSelf.transform.parent.parent.GetChild(0).GetChild(level-1).gameObject)) return false;
        return true;
    }

    public bool UpdateSpawner(GameObject gameObject)
    {
        for(int i = 0; i < gameObject.transform.childCount; i++) gameObject.transform.GetChild(i).gameObject.SetActive(true);
        return true;
    }
}
