using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    public class LootState
    {
        public EnemyWorker enemyWorker;

        public EnemyLootSettings lootSettings;

        public LootPackage lootPackage;

        public LootState(EnemyWorker enemyWorker, EnemyLootSettings lootSettings)
        {
            this.enemyWorker = enemyWorker;
            this.lootSettings = lootSettings;
            lootPackage = lootSettings.lootPackage;
        }
    }

    public LootState lootState;

    public EnemyLoot(EnemyWorker enemyWorker) => lootState = new LootState(enemyWorker, enemyWorker.enemyAI.enemySettings.lootSettings);
}
