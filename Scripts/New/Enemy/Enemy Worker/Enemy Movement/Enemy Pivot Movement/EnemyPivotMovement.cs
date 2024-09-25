using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPivotMovement
{
    public class PivotMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public Vector3 targetDirection, projectedVelocity;
        public float stopDistance, distanceFromTarget, viewableAngle, movementSpeed;

        public PivotMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
            stopDistance = movementSettings.stopDistance;
            movementSpeed = movementSettings.movementSpeed;
        }
    }

    public PivotMovementState pivotMovementState;

    public EnemyPivotMovement(EnemyWorker enemyWorker) => pivotMovementState = new PivotMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public void HandlePivoting()
    {
        if (pivotMovementState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isRotateWithRootMotion &&
            pivotMovementState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting) return;

        pivotMovementState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);
        pivotMovementState.targetDirection = pivotMovementState.enemyWorker.player.position - pivotMovementState.enemyWorker.enemyAI.transform.position;
        pivotMovementState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.targetDirection = pivotMovementState.targetDirection;
        pivotMovementState.viewableAngle = Vector3.SignedAngle(
            pivotMovementState.targetDirection,
            pivotMovementState.enemyWorker.enemyAI.transform.forward,
            Vector3.up);

        if (pivotMovementState.viewableAngle >= 100 && pivotMovementState.viewableAngle <= 180)
            pivotMovementState.enemyWorker.enemyAnimation.PlayTargetAnimationWithRootRotation("Turn Back Left", true);
        else if (pivotMovementState.viewableAngle <= -101 && pivotMovementState.viewableAngle >= -180)
            pivotMovementState.enemyWorker.enemyAnimation.PlayTargetAnimationWithRootRotation("Turn Back Right", true);
        else if (pivotMovementState.viewableAngle <= -45 && pivotMovementState.viewableAngle >= -100)
            pivotMovementState.enemyWorker.enemyAnimation.PlayTargetAnimationWithRootRotation("Turn Right", true);
        else if (pivotMovementState.viewableAngle >= 45 && pivotMovementState.viewableAngle <= 100)
            pivotMovementState.enemyWorker.enemyAnimation.PlayTargetAnimationWithRootRotation("Turn Left", true);
    }
}
