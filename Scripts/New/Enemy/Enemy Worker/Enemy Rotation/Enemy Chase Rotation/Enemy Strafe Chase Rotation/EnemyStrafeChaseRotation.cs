using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafeChaseRotation
{
    public class StrafeChaseRotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public Vector3 direction;
        public Quaternion targetRotation;
        public float rotationSpeed;
        public float verticalMovementValue, horizontalMovementValue;

        public bool isRandomDestinationSet;

        public StrafeChaseRotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            rotationSpeed = 5f;
        }
    }

    public StrafeChaseRotationState strafeChaseRotationState;

    public EnemyStrafeChaseRotation(EnemyWorker enemyWorker) => strafeChaseRotationState = new StrafeChaseRotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);

    public void HandleStrafeChaseRotation()
    {
        if (!strafeChaseRotationState.isRandomDestinationSet)
        {
            strafeChaseRotationState.isRandomDestinationSet = true;
            DecideCirclingAction();
        }
    }

    public void DecideCirclingAction()
    {
        WalkAroundTarget();
    }

    public void WalkAroundTarget()
    {
        strafeChaseRotationState.verticalMovementValue = 0.5f;

        strafeChaseRotationState.horizontalMovementValue = Random.Range(-1, 1);

        if (strafeChaseRotationState.horizontalMovementValue <= 1 && strafeChaseRotationState.horizontalMovementValue > 0)
            strafeChaseRotationState.horizontalMovementValue = 0.5f;
        else if (strafeChaseRotationState.horizontalMovementValue >= -1 && strafeChaseRotationState.horizontalMovementValue < 0)
            strafeChaseRotationState.horizontalMovementValue = -0.5f;

        strafeChaseRotationState.enemyWorker.enemyAnimation.UpdateAnimator(strafeChaseRotationState.verticalMovementValue, strafeChaseRotationState.horizontalMovementValue);
    }
}
