using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyAnimation
{
    public class AnimationState
    {
        public EnemyWorker enemyWorker;

        public EnemyAnimationSettings animationSettings;

        public Animator animator;

        public int horizontal, vertical;

        public bool canRotate;

        public AnimationState(EnemyWorker enemyWorker, EnemyAnimationSettings animationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.animationSettings = animationSettings;
            animator = animationSettings.animator;
            horizontal = Animator.StringToHash("Horizontal");
            vertical = Animator.StringToHash("Vertical");
        }
    }

    public AnimationState animationState;

    public EnemyAnimation(EnemyWorker enemyWorker) => animationState = new AnimationState(enemyWorker, enemyWorker.enemyAI.enemySettings.animationSettings);

    public void UpdateAnimator(float vertical, float horizontal)
    {
        animationState.animator.SetFloat(animationState.horizontal, horizontal, 0.1f, Time.deltaTime);
        animationState.animator.SetFloat(animationState.vertical, vertical, 0.1f, Time.deltaTime);
    }

    public void PlayTargetAnimation(string targetAnimation, bool isInteracting)
    {
        animationState.animator.applyRootMotion = isInteracting;
        animationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting = isInteracting;
        animationState.animator.CrossFade(targetAnimation, 0.2f);
    }

    public void PlayTargetAnimationWithRootRotation(string targetAnimation, bool isInteracting)
    {
        animationState.animator.applyRootMotion = isInteracting;
        animationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isRotateWithRootMotion = true;
        animationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting = isInteracting;
        animationState.animator.CrossFade(targetAnimation, 0.2f);
    }
}