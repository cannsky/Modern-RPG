using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats
{
    public class StatsState
    {
        public EnemyWorker enemyWorker;

        public EnemyStatsSettings statsSettings;

        public EnemyActionStats enemyActionStats;
        public EnemyElementStats enemyElementStats;
        public EnemyHealthStats enemyHealthStats;
        public EnemyMultiplierStats enemyMultiplierStats;

        public StatsState(EnemyWorker enemyWorker, EnemyStatsSettings statsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.statsSettings = statsSettings;
            enemyActionStats = new EnemyActionStats(enemyWorker);
            enemyElementStats = new EnemyElementStats(enemyWorker);
            enemyHealthStats = new EnemyHealthStats(enemyWorker);
            enemyMultiplierStats = new EnemyMultiplierStats(enemyWorker);
        }
    }

    public StatsState statsState;

    public EnemyStats(EnemyWorker enemyWorker) => statsState = new StatsState(enemyWorker, enemyWorker.enemyAI.enemySettings.statsSettings);

    public void Update() => statsState.enemyHealthStats.HealthRegeneration();
}
