using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMultiplierStats
{
    public class MultiplierStatsState
    {
        public EnemyWorker enemyWorker;

        public EnemyStatsSettings statsSettings;

        public float healthRegenerationMultiplier;

        public MultiplierStatsState(EnemyWorker enemyWorker, EnemyStatsSettings statsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.statsSettings = statsSettings;
            healthRegenerationMultiplier = statsSettings.multiplierStatsSettings.healthRegenerationMultiplier;
        }
    }

    public MultiplierStatsState multiplierStatsState;

    public EnemyMultiplierStats(EnemyWorker enemyWorker) => multiplierStatsState = new MultiplierStatsState(enemyWorker, enemyWorker.enemyAI.enemySettings.statsSettings);
}
