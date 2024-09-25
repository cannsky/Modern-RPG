using System.Collections;
using UnityEngine;

public class EnemyAttack
{
    public class AttackState
    {
        public EnemyWorker enemyWorker;

        public EnemyAttackSettings attackSettings;

        public Vector3 targetDirection;

        public float viewableAngle, currentRecoveryTime;

        //OLD

        public bool isCooldownEnded = true;

        public AttackState(EnemyWorker enemyWorker, EnemyAttackSettings attackSettings)
        {
            this.enemyWorker = enemyWorker;
            this.attackSettings = attackSettings;
        }
    }

    public AttackState attackState;

    public EnemyAttack(EnemyWorker enemyWorker) => attackState = new AttackState(enemyWorker, enemyWorker.enemyAI.enemySettings.attackSettings);

    public void Update() => HandleRecoveryTimer();

    public void HandleAttack()
    {
        if (attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting &&
            attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering) return;

        attackState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);

        if (attackState.enemyWorker.enemyBehaviour.behaviourState.attackBehaviour.attackBehaviourState.currentAttackBehaviour == null)
        {
            attackState.enemyWorker.enemyBehaviour.behaviourState.attackBehaviour.GetAttackBehaviour();
            attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking = true;
            attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting = true;
            attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering = true;
            attackState.currentRecoveryTime = attackState.enemyWorker.enemyBehaviour.behaviourState.attackBehaviour.attackBehaviourState.currentAttackBehaviour.recoveryTime;
            attackState.enemyWorker.enemyAnimation.PlayTargetAnimation(attackState.enemyWorker.enemyBehaviour.behaviourState.attackBehaviour.attackBehaviourState.currentAttackBehaviour.animationName, true);
            attackState.enemyWorker.enemyWeapon.weaponState.enemyWeaponCollision.weaponCollisionState.isAttackStarted = true;
        }
    }

    public void HandleRecoveryTimer()
    {
        if (attackState.currentRecoveryTime > 0) attackState.currentRecoveryTime -= Time.deltaTime;
        else if (attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering && attackState.currentRecoveryTime <= 0)
            attackState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering = false;
    }
}