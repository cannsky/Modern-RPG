using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeBehaviour : EnemyAIBehaviour
{
    public class DodgeBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyCombatStanceBehaviourSettings combatStanceBehaviourSettings;

        public DodgeBehaviourState(EnemyWorker enemyWorker, EnemyCombatStanceBehaviourSettings combatStanceBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.combatStanceBehaviourSettings = combatStanceBehaviourSettings;
        }
    }

    public DodgeBehaviourState dodgeBehaviourState;

    public EnemyDodgeBehaviour(EnemyWorker enemyWorker) => dodgeBehaviourState = new DodgeBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.combatStanceBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        return HandleBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {

    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour() => null;

    public override EnemyAIBehaviour HandleBehaviour()
    {
        dodgeBehaviourState.enemyWorker.enemyDodge.TryDodge();
        dodgeBehaviourState.enemyWorker.enemyRotation.rotationState.enemyDodgeRotation.RotateTowardsPlayer();
        if (dodgeBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDodging) return this;
        else return dodgeBehaviourState.enemyWorker.enemyBehaviour.behaviourState.combatStanceBehaviour;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour() => null;
}