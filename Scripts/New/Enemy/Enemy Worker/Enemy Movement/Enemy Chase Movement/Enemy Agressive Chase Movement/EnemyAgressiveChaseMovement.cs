using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgressiveChaseMovement
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

    public EnemyAgressiveChaseMovement(EnemyWorker enemyWorker) => normalChaseMovementState = new NormalChaseMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public bool HandleAgressiveChaseMovement()
    {
        normalChaseMovementState.enemyWorker.enemyAnimation.UpdateAnimator(1, 0f);
        normalChaseMovementState.enemyWorker.enemyRotation.rotationState.enemyChaseRotation.chaseRotationState.enemyRunChaseRotation.HandleRunChaseMovementRotation();
        return true;
    }
}
