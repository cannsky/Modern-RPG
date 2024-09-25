using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafeBehaviour : EnemyAIBehaviour
{
    public class StrafeBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyIdleBehaviourSettings idleBehaviourSettings;

        public StrafeBehaviourState(EnemyWorker enemyWorker, EnemyIdleBehaviourSettings idleBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.idleBehaviourSettings = idleBehaviourSettings;
        }
    }

    public StrafeBehaviourState strafeBehaviourState;

    public EnemyStrafeBehaviour(EnemyWorker enemyWorker) => strafeBehaviourState = new StrafeBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.idleBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        if (strafeBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting) return HandleDowngradeBehaviour();
        else if (!strafeBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering) return HandleDowngradeBehaviour();
        else return HandleBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {
        
    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour()
    {
        return strafeBehaviourState.enemyWorker.enemyBehaviour.behaviourState.combatStanceBehaviour;
    }

    public override EnemyAIBehaviour HandleBehaviour()
    {
        return this;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour() => null;
}
