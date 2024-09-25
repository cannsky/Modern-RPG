using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResetAnimator : StateMachineBehaviour
{
    public List<string> targetBooleans;
    public bool isAttackAnimation, isDodgeAnimation, isReviveAnimation;
    public bool status;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach(string targetBool in targetBooleans) animator.SetBool(targetBool, status);
        if (isAttackAnimation) ResetStatesOnAttackEnd();
        if (isDodgeAnimation) ResetStatesOnDodgeEnd();
        if (isReviveAnimation) ResetStatsOnReviveEnd();
    }

    public void ResetStatesOnAttackEnd()
    {
        Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking = false;
        Player.Instance.playerWorker.playerWeapon.weaponState.playerWeaponCollision.weaponCollisionState.isWaiting = false;
        Player.Instance.playerWorker.playerCombatTechnique.combatTechniqueState.playerCombatTechniqueQueue.combatTechniqueQueueState.combatTechniqueAttackComboTime = 0f;
        Player.Instance.playerWorker.playerCombatTechnique.combatTechniqueState.playerCombatTechniqueQueue.combatTechniqueQueueState.isCombatTechniqueReady = true;
        Player.Instance.playerWorker.playerAnimation.animationState.animators[0].SetBool("isDamaged", false);
    }

    public void ResetStatesOnDodgeEnd()
    {
        Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isRolling = false;
    }

    public void ResetStatsOnReviveEnd()
    {
        Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isReviving = false;
    }
}
