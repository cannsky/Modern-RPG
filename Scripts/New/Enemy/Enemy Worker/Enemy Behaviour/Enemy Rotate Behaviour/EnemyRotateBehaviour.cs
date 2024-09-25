using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotateBehaviour : EnemyAIBehaviour
{

    public class RotateBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotateBehaviourSettings rotateBehaviourSettings;

        public RotateBehaviourState(EnemyWorker enemyWorker, EnemyRotateBehaviourSettings rotateBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotateBehaviourSettings = rotateBehaviourSettings;
        }
    }

    public RotateBehaviourState rotateBehaviourState;

    public EnemyRotateBehaviour(EnemyWorker enemyWorker) => rotateBehaviourState = new RotateBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.rotateBehaviourSettings);

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
        if (rotateBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking) 
            rotateBehaviourState.enemyWorker.enemyRotation.rotationState.enemyAttackRotation.HandleRotation();
        else if(rotateBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDodging) 
            rotateBehaviourState.enemyWorker.enemyMovement.movementState.enemyPivotMovement.HandlePivoting();
        else rotateBehaviourState.enemyWorker.enemyMovement.movementState.enemyPivotMovement.HandlePivoting();
        return rotateBehaviourState.enemyWorker.enemyBehaviour.behaviourState.combatStanceBehaviour;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour() => null;
}
