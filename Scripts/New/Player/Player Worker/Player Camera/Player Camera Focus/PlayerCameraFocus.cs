using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFocus
{
    public class CameraFocusState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public PlayerCameraFocusQueue playerCameraFocusQueue;

        public Transform lockTransform, leftLockTransform, rightLockTransform;

        public Vector3 relativeEnemyPosition;

        public float distanceFromLeftTarget, distanceFromRightTarget;
        public float shortestDistanceOfLeftTarget, shortestDistanceOfRightTarget;

        public CameraFocusState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;
            playerCameraFocusQueue = new PlayerCameraFocusQueue(playerWorker);
        }
    }

    public CameraFocusState cameraFocusState;

    public PlayerCameraFocus(PlayerWorker playerWorker) => cameraFocusState = new CameraFocusState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void HandleCameraFocus(bool isChangeLockToLeftTarget)
    {
        cameraFocusState.leftLockTransform = cameraFocusState.rightLockTransform = null;
        cameraFocusState.playerCameraFocusQueue.GenerateList();
        cameraFocusState.shortestDistanceOfLeftTarget = Mathf.Infinity;
        cameraFocusState.shortestDistanceOfRightTarget = Mathf.Infinity;
        foreach(EnemyAI enemyAI in cameraFocusState.playerCameraFocusQueue.cameraFocusQueueState.enemyList)
        {
            cameraFocusState.relativeEnemyPosition = cameraFocusState.lockTransform.InverseTransformPoint(enemyAI.transform.position);
            cameraFocusState.distanceFromLeftTarget = cameraFocusState.lockTransform.position.x - enemyAI.transform.position.x;
            cameraFocusState.distanceFromRightTarget = cameraFocusState.lockTransform.position.x + enemyAI.transform.position.x;

            if(cameraFocusState.relativeEnemyPosition.x > 0 && cameraFocusState.distanceFromLeftTarget < cameraFocusState.shortestDistanceOfLeftTarget)
            {
                cameraFocusState.shortestDistanceOfLeftTarget = cameraFocusState.distanceFromLeftTarget;
                cameraFocusState.leftLockTransform = enemyAI.enemyWorker.enemyCamera.cameraState.lookTransform;
            }

            if (cameraFocusState.relativeEnemyPosition.x < 0 && cameraFocusState.distanceFromRightTarget < cameraFocusState.shortestDistanceOfRightTarget)
            {
                cameraFocusState.shortestDistanceOfRightTarget = cameraFocusState.distanceFromRightTarget;
                cameraFocusState.rightLockTransform = enemyAI.enemyWorker.enemyCamera.cameraState.lookTransform;
            }
        }

        if (isChangeLockToLeftTarget) cameraFocusState.lockTransform = cameraFocusState.leftLockTransform;
        else cameraFocusState.lockTransform = cameraFocusState.rightLockTransform;
    }
}
