using System.Collections;
using UnityEngine;
using Mandeshire;

public class PlayerAnimation
{
    public class AnimationState
    {
        public PlayerWorker playerWorker;

        public PlayerAnimationSettings animationSettings;

        public Animator[] animators;

        public int horizontal, vertical;

        public float h, v;

        public bool canRotate = true;

        public AnimationState(PlayerWorker playerWorker, PlayerAnimationSettings animationSettings)
        {
            this.playerWorker = playerWorker;
            this.animationSettings = animationSettings;
            animators = animationSettings.animators;
            horizontal = Animator.StringToHash("Horizontal");
            vertical = Animator.StringToHash("Vertical");
        }
    }

    public AnimationState animationState;

    public PlayerAnimation(PlayerWorker playerWorker) => animationState = new AnimationState(playerWorker, playerWorker.player.playerSettings.animationSettings);

    public void FixedUpdate() => UpdateCanRotate();

    public void ChangePlayerStance()
    {
        PlayTargetAnimation(animationState.playerWorker.playerStance.stanceState.isStanceB ? "A to B" : "B to A", true); 
        UpdateStanceValue();
    }

    public void UpdateStanceValue()
    {
        foreach (Animator animator in animationState.animators) 
            animator.SetBool("isLocomotionTypeB", animationState.playerWorker.playerStance.stanceState.isStanceB);
    }

    public void UpdateAnimator(float verticalMovement, float horizontalMovement)
    {
        animationState.h = !animationState.playerWorker.playerUI.CheckUIOpened() ? 
            CalculateHorizontalValue(horizontalMovement) : 
            CalculateHorizontalValue(0);
        animationState.v = !animationState.playerWorker.playerUI.CheckUIOpened() ? 
            CalculateVerticalValue(verticalMovement) :
            CalculateVerticalValue(0);

        foreach (Animator animator in animationState.animators)
        {
            animator.SetFloat(animationState.horizontal, animationState.h, 0.1f, Time.deltaTime);
            animator.SetFloat(animationState.vertical, animationState.v, 0.1f, Time.deltaTime);
        }
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        foreach (Animator animator in animationState.animators)
        {
            animator.applyRootMotion = isInteracting;
            animator.SetBool("isInteracting", isInteracting);
            animator.CrossFade(targetAnimation, 0.2f);
        }
    }

    public float CalculateVerticalValue(float verticalMovement)
    {
        if (animationState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting) return 2f;
        else if (verticalMovement > 0f && verticalMovement < 0.55f) return 0.5f;
        else if (verticalMovement > 0.55f) return 1f;
        else if (verticalMovement < 0f && verticalMovement > -0.55f) return -0.5f;
        else if (verticalMovement < -0.55f) return -1f;
        else return 0f;
    }

    public float CalculateHorizontalValue(float horizontalMovement)
    {
        if (horizontalMovement > 0f && horizontalMovement < 0.55f) return 0.5f;
        else if (horizontalMovement > 0.55f) return 1f;
        else if (horizontalMovement < 0f && horizontalMovement > -0.55f) return -0.5f;
        else if (horizontalMovement < -0.55f) return -1f;
        else return 0f;
    }

    public void UpdateCanRotate()
    {
        if (animationState.h != 0 || animationState.v != 0) animationState.canRotate = true;
        else if (animationState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking) animationState.canRotate = true;
        else animationState.canRotate = false;
    }
}
