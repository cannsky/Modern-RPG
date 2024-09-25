using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCamera
{
    public class CameraState
    {
        public EnemyWorker enemyWorker;

        public EnemyCameraSettings cameraSettings;

        public Transform lookTransform;

        public bool isPlayerCameraUpdated;

        public CameraState(EnemyWorker enemyWorker, EnemyCameraSettings cameraSettings)
        {
            this.enemyWorker = enemyWorker;
            this.cameraSettings = cameraSettings;
            lookTransform = cameraSettings.lookTransform;
        }
    }

    public CameraState cameraState;

    public EnemyCamera(EnemyWorker enemyWorker) => cameraState = new CameraState(enemyWorker, enemyWorker.enemyAI.enemySettings.cameraSettings);

    public void AddToPlayerCameraFocusQueue()
    {
        if (cameraState.isPlayerCameraUpdated) return;
        Player.Instance.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.playerCameraFocusQueue.AddEnemy(cameraState.enemyWorker.enemyAI);
        cameraState.isPlayerCameraUpdated = true;
    }

    public void RemoveFromPlayerCameraFocusQueue()
    {
        if (!cameraState.isPlayerCameraUpdated) return;
        Player.Instance.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.playerCameraFocusQueue.RemoveEnemy(cameraState.enemyWorker.enemyAI);
        cameraState.isPlayerCameraUpdated = false;
    }
}
