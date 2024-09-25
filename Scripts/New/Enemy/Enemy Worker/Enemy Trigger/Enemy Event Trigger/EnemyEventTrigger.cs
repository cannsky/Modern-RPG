using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEventTrigger
{
    public class EventTriggerState
    {
        public EnemyWorker enemyWorker;

        public EnemyTriggerSettings triggerSettings;

        public EnemyDeathEventTrigger enemyDeathEventTrigger;

        public EventTriggerState(EnemyWorker enemyWorker, EnemyTriggerSettings triggerSettings)
        {
            this.enemyWorker = enemyWorker;
            this.triggerSettings = triggerSettings;
            enemyDeathEventTrigger = new EnemyDeathEventTrigger(enemyWorker);
        }
    }

    public EventTriggerState eventTriggerState;

    public EnemyEventTrigger(EnemyWorker enemyWorker) => eventTriggerState = new EventTriggerState(enemyWorker, enemyWorker.enemyAI.enemySettings.triggerSettings);
}
