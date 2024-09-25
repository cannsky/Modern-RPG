using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyElementStats
{
    public class ElementStatsState
    {
        public EnemyWorker enemyWorker;

        public EnemyStatsSettings statsSettings;

        public int element;

        public ElementStatsState(EnemyWorker enemyWorker, EnemyStatsSettings statsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.statsSettings = statsSettings;
            element = (int) statsSettings.elementStatsSettings.element;
        }
    }

    public ElementStatsState elementStatsState;

    public EnemyElementStats(EnemyWorker enemyWorker) => elementStatsState = new ElementStatsState(enemyWorker, enemyWorker.enemyAI.enemySettings.statsSettings);
}
