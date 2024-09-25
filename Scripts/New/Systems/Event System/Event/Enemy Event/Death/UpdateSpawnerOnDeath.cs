using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Enemy Event/Death Event/Update Spawner On Death", order = 1)]
public class UpdateSpawnerOnDeath : EnemyEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!UpdateSpawner(base.gameObjectSelf.transform.parent.gameObject)) return false;
        return true;
    }

    public bool UpdateSpawner(GameObject gameObject)
    {
        gameObject.GetComponent<SpawnerLevelEndTrigger>().OnSpawnerEnemyDead();
        return true;
    }
}
