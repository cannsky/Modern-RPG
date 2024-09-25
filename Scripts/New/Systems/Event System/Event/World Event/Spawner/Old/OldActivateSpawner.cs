using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Old Game Event/World Event/Old Spawner Event/Old Activate Spawner", order = 1)]
public class OldActivateSpawner : WorldEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectTargetList)
            foreach (GameObject gameObject in base.effectedGameObjectList) if (!UpdateSpawner(gameObject)) return false;
        if (base.isEffectTarget)
            if (!UpdateSpawner(base.gameObjectTarget)) return false;
        if (base.isEffectItSelf)
            if (!UpdateSpawner(base.gameObjectSelf)) return false;
        return true;
    }

    public bool UpdateSpawner(GameObject gameObject)
    {
        Spawner spawner = gameObject.GetComponent<Spawner>();
        if (!spawner.spawnerState.isSpawnerStarted) spawner.SpawnEnemy();
        spawner.SetEnemiesActive();
        return true;
    }
}
