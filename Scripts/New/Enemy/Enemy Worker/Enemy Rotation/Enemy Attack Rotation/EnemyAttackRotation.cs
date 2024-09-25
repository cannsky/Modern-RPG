using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRotation
{
    public class AttackRotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public Vector3 direction;
        public Quaternion targetRotation;
        public float rotationSpeed;

        public AttackRotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            rotationSpeed = 5f;
        }
    }

    public AttackRotationState attackRotationState;

    public EnemyAttackRotation(EnemyWorker enemyWorker) => attackRotationState = new AttackRotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);

    public void HandleRotation() => RotateTowardsPlayer();

    public void RotateTowardsPlayer()
    {
        if (!attackRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isCanRotate &&
            !attackRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking) return;
        attackRotationState.direction = attackRotationState.enemyWorker.player.position - attackRotationState.enemyWorker.enemyAI.transform.position;
        attackRotationState.direction.y = 0;
        attackRotationState.direction.Normalize();

        if (attackRotationState.direction == Vector3.zero) attackRotationState.direction = attackRotationState.enemyWorker.enemyAI.transform.forward;

        attackRotationState.targetRotation = Quaternion.LookRotation(attackRotationState.direction);
        attackRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(
            attackRotationState.enemyWorker.enemyAI.transform.rotation,
            attackRotationState.targetRotation,
            attackRotationState.rotationSpeed / Time.deltaTime);
    }
}
