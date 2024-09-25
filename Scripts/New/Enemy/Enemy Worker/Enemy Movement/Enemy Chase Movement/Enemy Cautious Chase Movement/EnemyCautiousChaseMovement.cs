using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCautiousChaseMovement
{
    public class CautiousChaseMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public bool isStrafeDirectionDecided;

        public float strafeSign = 1f;

        public CautiousChaseMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
        }
    }

    public CautiousChaseMovementState cautiousChaseMovementState;

    public EnemyCautiousChaseMovement(EnemyWorker enemyWorker) => cautiousChaseMovementState = new CautiousChaseMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public bool HandleCautiousChaseMovement()
    {
        if (!cautiousChaseMovementState.isStrafeDirectionDecided) ResetStrafeDirection();
        cautiousChaseMovementState.enemyWorker.enemyAnimation.UpdateAnimator(0.4f, 0.25f * 1f);
        cautiousChaseMovementState.enemyWorker.enemyRotation.rotationState.enemyChaseRotation.chaseRotationState.enemyRunChaseRotation.HandleRunChaseMovementRotation();
        return true;
    }

    public void ResetStrafeDirection()
    {
        cautiousChaseMovementState.isStrafeDirectionDecided = true;
        cautiousChaseMovementState.strafeSign = Random.Range(0, 1f) >= 0.5f ? 1f : -1f;
        cautiousChaseMovementState.enemyWorker.enemyAI.StartCoroutine(ResetStrafeDirectionAfterTime());
    }

    public IEnumerator ResetStrafeDirectionAfterTime()
    {
        yield return new WaitForSeconds(25f);
        cautiousChaseMovementState.isStrafeDirectionDecided = false;
    }
}
