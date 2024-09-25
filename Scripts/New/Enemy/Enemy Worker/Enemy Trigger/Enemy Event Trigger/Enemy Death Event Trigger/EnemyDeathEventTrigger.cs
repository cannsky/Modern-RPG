using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathEventTrigger
{
    public class DeathEventTriggerState
    {
        public EnemyWorker enemyWorker;

        public EnemyDeathEventTriggerSettings deathEventTriggerSettings;

        public GameEvent gameEvent;

        public DeathEventTriggerState(EnemyWorker enemyWorker, EnemyDeathEventTriggerSettings deathEventTriggerSettings)
        {
            this.enemyWorker = enemyWorker;
            this.deathEventTriggerSettings = deathEventTriggerSettings;
            gameEvent = deathEventTriggerSettings.gameEvent;
        }
    }

    public DeathEventTriggerState deathEventTriggerState;

    public EnemyDeathEventTrigger(EnemyWorker enemyWorker) => deathEventTriggerState = new DeathEventTriggerState(enemyWorker, enemyWorker.enemyAI.enemySettings.triggerSettings.eventTriggerSettings.deathEventTriggerSettings);

    public void TriggerDeathEvent()
    {
        EventSystem.HandleGameEvent(deathEventTriggerState.gameEvent, deathEventTriggerState.enemyWorker.enemyAI.gameObject);
    }
}
