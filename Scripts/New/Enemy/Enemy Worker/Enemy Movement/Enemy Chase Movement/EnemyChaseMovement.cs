using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseMovement
{
    public class ChaseMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public EnemyAgressiveChaseMovement enemyAgressiveChaseMovement;
        public EnemyCautiousChaseMovement enemyCautiousChaseMovement;
        public EnemyNormalChaseMovement enemyNormalChaseMovement;

        public Vector3 targetDirection, projectedVelocity;
        public float stopDistance, distanceFromTarget, viewableAngle, movementSpeed;

        public ChaseMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
            enemyAgressiveChaseMovement = new EnemyAgressiveChaseMovement(enemyWorker);
            enemyCautiousChaseMovement = new EnemyCautiousChaseMovement(enemyWorker);
            enemyNormalChaseMovement = new EnemyNormalChaseMovement(enemyWorker);
            stopDistance = movementSettings.stopDistance;
            movementSpeed = movementSettings.movementSpeed;
        }
    }

    public ChaseMovementState chaseMovementState;

    public EnemyChaseMovement(EnemyWorker enemyWorker) => chaseMovementState = new ChaseMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public void HandleChase()
    {
        if (chaseMovementState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting) return;

        chaseMovementState.targetDirection = chaseMovementState.enemyWorker.player.position - chaseMovementState.enemyWorker.enemyAI.transform.position;
        chaseMovementState.distanceFromTarget = Vector3.Distance(chaseMovementState.enemyWorker.player.position, chaseMovementState.enemyWorker.enemyAI.transform.position);
        chaseMovementState.viewableAngle = Vector3.SignedAngle(chaseMovementState.targetDirection, chaseMovementState.enemyWorker.enemyAI.transform.forward, Vector3.up);

        if (chaseMovementState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting)
        {
            chaseMovementState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);
            chaseMovementState.enemyWorker.enemyAgent.agentState.navMeshAgent.enabled = false;
        }
        else if (chaseMovementState.distanceFromTarget > chaseMovementState.stopDistance) HandleChaseMovement();
        else chaseMovementState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);

        chaseMovementState.enemyWorker.enemyMovement.movementState.enemyRigidbodyMovement.HandleRigidbodyMovement();
        chaseMovementState.enemyWorker.enemyAgent.ResetAgentTransform();
    }

    public bool HandleChaseMovement()
    {
        return (int)chaseMovementState.enemyWorker.enemyType.typeState.enemyMovementType.movementTypeState.movementType switch
        {
            0 => chaseMovementState.enemyCautiousChaseMovement.HandleCautiousChaseMovement(),
            1 => chaseMovementState.enemyNormalChaseMovement.HandleNormalChaseMovement(),
            2 => chaseMovementState.enemyAgressiveChaseMovement.HandleAgressiveChaseMovement(),
            _ => throw new System.NotImplementedException()
        };
    }
}
