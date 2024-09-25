using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraFollow
{
    public class CameraFollowState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public Transform cameraTransform, cameraPivotTransform, cameraHolderTransform, targetTransform;

        public Vector3 cameraTransformPosition, targetPosition, cameraFollowVelocity;

        public float followSpeed, defaultPosition;

        public CameraFollowState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;
            cameraTransform = cameraSettings.cameraTransform;
            cameraPivotTransform = cameraSettings.cameraPivotTransform;
            targetTransform = cameraSettings.targetTransform;
            cameraHolderTransform = cameraSettings.cameraHolderTransform;
            followSpeed = cameraSettings.followSpeed;
            cameraFollowVelocity = Vector3.zero;
        }
    }

    public CameraFollowState cameraFollowState;

    public PlayerCameraFollow(PlayerWorker playerWorker) => cameraFollowState = new CameraFollowState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void Awake() => cameraFollowState.defaultPosition = cameraFollowState.cameraTransform.localPosition.z;

    public void FixedUpdate() => FollowTarget(Time.deltaTime);

    public void FollowTarget(float delta)
    {
        cameraFollowState.targetPosition = Vector3.SmoothDamp(
            cameraFollowState.cameraHolderTransform.position,
            cameraFollowState.targetTransform.position,
            ref cameraFollowState.cameraFollowVelocity,
            delta / cameraFollowState.followSpeed);
        cameraFollowState.cameraHolderTransform.position = cameraFollowState.targetPosition;
    }
}
