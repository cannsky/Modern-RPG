using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyChaseMovement;

public class EnemyNormalChaseMovement
{
    public class NormalChaseMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public Vector3 targetDirection, projectedVelocity;
        public float stopDistance, distanceFromTarget, viewableAngle, movementSpeed;

        public NormalChaseMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
            stopDistance = movementSettings.stopDistance;
            movementSpeed = movementSettings.movementSpeed;
        }
    }

    public NormalChaseMovementState normalChaseMovementState;

    public EnemyNormalChaseMovement(EnemyWorker enemyWorker) => normalChaseMovementState = new NormalChaseMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public bool HandleNormalChaseMovement()
    {
        if (normalChaseMovementState.enemyWorker.enemyVision.CheckCautionRange())
            normalChaseMovementState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.enemyCautiousChaseMovement.HandleCautiousChaseMovement();
        else normalChaseMovementState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.enemyAgressiveChaseMovement.HandleAgressiveChaseMovement();
        return true;
    }
}
