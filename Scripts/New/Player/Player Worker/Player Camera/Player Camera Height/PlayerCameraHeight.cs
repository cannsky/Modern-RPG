using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerCameraFocusQueue;

public class PlayerCameraHeight
{
    public class CameraHeightState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public Vector3 velocity, lockedPosition, unlockedPosition;
        public float lockedPivotPosition, unlockedPivotPosition;

        public CameraHeightState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;
            lockedPivotPosition = cameraSettings.cameraHeightSettings.lockedPivotPosition;
            unlockedPivotPosition = cameraSettings.cameraHeightSettings.unlockedPivotPosition;
        }
    }

    public CameraHeightState cameraHeightState;

    public PlayerCameraHeight(PlayerWorker playerWorker) => cameraHeightState = new CameraHeightState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void SetCameraHeight()
    {
        cameraHeightState.velocity = Vector3.zero;
        cameraHeightState.lockedPosition = new Vector3(0, 4, cameraHeightState.lockedPivotPosition);
        cameraHeightState.unlockedPosition = new Vector3(0, 4, cameraHeightState.unlockedPivotPosition);

        if (cameraHeightState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform != null)
        {
            cameraHeightState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.localPosition =
                Vector3.SmoothDamp(
                    cameraHeightState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.localPosition,
                    cameraHeightState.lockedPosition,
                    ref cameraHeightState.velocity,
                    Time.deltaTime
                );
        }
        else
        {
            cameraHeightState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.localPosition =
                Vector3.SmoothDamp(
                    cameraHeightState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.transform.localPosition,
                    cameraHeightState.unlockedPosition,
                    ref cameraHeightState.velocity,
                    Time.deltaTime
                );
        }
    }
}
