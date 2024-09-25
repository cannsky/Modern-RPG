using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyResetAnimator : StateMachineBehaviour
{
    public bool isAttackAnimation, isDodgeAnimation, isReviveAnimation, isRotateAnimation;
    public bool status;
    public EnemyWorker enemyWorker;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyWorker = animator.gameObject.transform.parent.gameObject.GetComponent<EnemyAI>().enemyWorker;
        enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting = false;
        if (isAttackAnimation) ResetStatesOnAttackEnd(enemyWorker);
        if (isDodgeAnimation) ResetStatsOnDodgeEnd(enemyWorker);
        if (isRotateAnimation) ResetStatesOnRotateEnd(enemyWorker);
        if (isReviveAnimation) ResetStatesOnReviveEnd(enemyWorker);
    }

    public void ResetStatesOnAttackEnd(EnemyWorker enemyWorker)
    {
        enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking = false;
        enemyWorker.enemyBehaviour.behaviourState.attackBehaviour.attackBehaviourState.currentAttackBehaviour = null;
        enemyWorker.enemyWeapon.weaponState.enemyWeaponCollision.weaponCollisionState.isAttackStarted = false;
        enemyWorker.enemyWeapon.weaponState.enemyWeaponCollision.weaponCollisionState.isWaiting = false;
        enemyWorker.enemyAnimation.animationState.animator.SetBool("isDamaged", false);
    }

    public void ResetStatsOnDodgeEnd(EnemyWorker enemyWorker)
    {
        enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDodging = false;
    }

    public void ResetStatesOnRotateEnd(EnemyWorker enemyWorker)
    {
        enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isRotateWithRootMotion = false;
    }

    public void ResetStatesOnReviveEnd(EnemyWorker enemyWorker)
    {
        enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isReviving = false;
    }
}
