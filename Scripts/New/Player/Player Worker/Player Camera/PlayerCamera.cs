using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera
{
    public class CameraState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public PlayerCameraFocus playerCameraFocus;
        public PlayerCameraFollow playerCameraFollow;
        public PlayerCameraHeight playerCameraHeight; 
        public PlayerCameraRotation playerCameraRotation;

        public LayerMask ignoreLayers;

        public CameraState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;

            playerCameraFocus = new PlayerCameraFocus(playerWorker);
            playerCameraFollow = new PlayerCameraFollow(playerWorker);
            playerCameraHeight = new PlayerCameraHeight(playerWorker);
            playerCameraRotation = new PlayerCameraRotation(playerWorker);
        }
    }

    public CameraState cameraState;

    public PlayerCamera(PlayerWorker playerWorker) => cameraState = new CameraState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void Awake()
    {
        cameraState.playerCameraFollow.Awake();
        cameraState.ignoreLayers = ~(1 << 8 | 1 << 9 | 1 << 10 | 1 << 11 | 1 << 25);
    }

    public void FixedUpdate()
    {
        cameraState.playerCameraFollow.FixedUpdate();
        cameraState.playerCameraRotation.FixedUpdate();
    }
}
