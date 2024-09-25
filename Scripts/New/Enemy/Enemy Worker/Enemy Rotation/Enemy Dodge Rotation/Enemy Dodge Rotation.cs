using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodgeRotation
{
    public class DodgeRotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public Vector3 direction;
        public Quaternion targetRotation;
        public float rotationSpeed;

        public DodgeRotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            rotationSpeed = 5f;
        }
    }

    public DodgeRotationState dodgeRotationState;

    public EnemyDodgeRotation(EnemyWorker enemyWorker) => dodgeRotationState = new DodgeRotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);

    public void HandleRotation() => RotateTowardsPlayer();

    public void RotateTowardsPlayer()
    {
        if (!dodgeRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isCanRotate &&
            !dodgeRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking) return;
        dodgeRotationState.direction = dodgeRotationState.enemyWorker.player.position - dodgeRotationState.enemyWorker.enemyAI.transform.position;
        dodgeRotationState.direction.y = 0;
        dodgeRotationState.direction.Normalize();

        if (dodgeRotationState.direction == Vector3.zero) dodgeRotationState.direction = dodgeRotationState.enemyWorker.enemyAI.transform.forward;

        dodgeRotationState.targetRotation = Quaternion.LookRotation(dodgeRotationState.direction);
        dodgeRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(
            dodgeRotationState.enemyWorker.enemyAI.transform.rotation,
            dodgeRotationState.targetRotation,
            dodgeRotationState.rotationSpeed / Time.deltaTime);
    }
}
