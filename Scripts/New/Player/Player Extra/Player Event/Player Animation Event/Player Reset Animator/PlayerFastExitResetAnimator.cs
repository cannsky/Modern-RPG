using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFastExitResetAnimator : StateMachineBehaviour
{
    public bool isAttackAnimation;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isAttackAnimation) ResetStatesOnFastExit();
    }

    public void ResetStatesOnFastExit()
    {
        Player.Instance.playerWorker.playerVFX.vfxState.playerTrailVFX.DisableTrails();
    }
}
