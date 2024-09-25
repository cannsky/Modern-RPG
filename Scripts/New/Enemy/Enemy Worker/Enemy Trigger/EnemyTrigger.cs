using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger
{
    public class TriggerState
    {
        public EnemyWorker enemyWorker;

        public EnemyTriggerSettings triggerSettings;

        public EnemyEventTrigger enemyEventTrigger;

        public TriggerState(EnemyWorker enemyWorker, EnemyTriggerSettings triggerSettings)
        {
            this.enemyWorker = enemyWorker;
            this.triggerSettings = triggerSettings;
            enemyEventTrigger = new EnemyEventTrigger(enemyWorker);
        }
    }

    public TriggerState triggerState;

    public EnemyTrigger(EnemyWorker enemyWorker) => triggerState = new TriggerState(enemyWorker, enemyWorker.enemyAI.enemySettings.triggerSettings);
}
