using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStrafeMovement
{
    public class StrafeMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public bool isRandomDestinationSet;

        public float verticalMovementValue, horizontalMovementValue;

        public StrafeMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
        }
    }

    public StrafeMovementState strafeMovementState;

    public EnemyStrafeMovement(EnemyWorker enemyWorker) => strafeMovementState = new StrafeMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public void HandleStrafe()
    {
        
    }

    public void DecideCirclingAction()
    {

    }

    public void WalkAroundTarget()
    {
        strafeMovementState.verticalMovementValue = Random.Range(0, 1);

        if (strafeMovementState.verticalMovementValue <= 1 && strafeMovementState.verticalMovementValue > 0)
            strafeMovementState.verticalMovementValue = 0.5f;
        else if (strafeMovementState.verticalMovementValue >= -1 && strafeMovementState.verticalMovementValue < 0)
            strafeMovementState.verticalMovementValue = -0.5f;

        strafeMovementState.horizontalMovementValue = Random.Range(-1, 1);

        if (strafeMovementState.horizontalMovementValue <= 1 && strafeMovementState.horizontalMovementValue > 0)
            strafeMovementState.horizontalMovementValue = 0.5f;
        else if (strafeMovementState.horizontalMovementValue >= -1 && strafeMovementState.horizontalMovementValue < 0)
            strafeMovementState.horizontalMovementValue = -0.5f;

        strafeMovementState.enemyWorker.enemyAnimation.UpdateAnimator(strafeMovementState.verticalMovementValue, strafeMovementState.horizontalMovementValue);
    }
}
