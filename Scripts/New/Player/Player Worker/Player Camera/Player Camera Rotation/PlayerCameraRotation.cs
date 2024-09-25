using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraRotation
{
    public class CameraRotationState
    {
        public PlayerWorker playerWorker;

        public PlayerCameraSettings cameraSettings;

        public Quaternion targetRotation, focusedTargetRotation;

        public Vector3 rotation, direction, eulerAngles;

        public float lookAngle, pivotAngle;
        public float lookSpeed, pivotSpeed;
        public float maximumPivot, minimumPivot;
        public float velocity;

        public CameraRotationState(PlayerWorker playerWorker, PlayerCameraSettings cameraSettings)
        {
            this.playerWorker = playerWorker;
            this.cameraSettings = cameraSettings;
            lookSpeed = cameraSettings.lookSpeed;
            pivotSpeed = cameraSettings.pivotSpeed;
            maximumPivot = cameraSettings.maximumPivot;
            minimumPivot = cameraSettings.minimumPivot;
        }
    }

    public CameraRotationState cameraRotationState;

    public PlayerCameraRotation(PlayerWorker playerWorker) => cameraRotationState = new CameraRotationState(playerWorker, playerWorker.player.playerSettings.cameraSettings);

    public void FixedUpdate() => HandleCameraRotation(
            Time.deltaTime,
            cameraRotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.mouseX,
            cameraRotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.mouseY);

    public void HandleCameraRotation(float delta, float mouseXInput, float mouseYInput)
    {
        if (cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform == null) NormalRotation(delta, mouseXInput, mouseYInput);
        else FocusedRotation();
    }

    public void NormalRotation(float delta, float mouseXInput, float mouseYInput)
    {
        cameraRotationState.lookAngle += (mouseXInput * cameraRotationState.lookSpeed) / delta;
        cameraRotationState.pivotAngle -= (mouseYInput * cameraRotationState.pivotSpeed) / delta;
        cameraRotationState.pivotAngle = Mathf.Clamp(cameraRotationState.pivotAngle, cameraRotationState.minimumPivot, cameraRotationState.maximumPivot);

        cameraRotationState.rotation = Vector3.zero;
        cameraRotationState.rotation.y = cameraRotationState.lookAngle;
        cameraRotationState.targetRotation = Quaternion.Euler(cameraRotationState.rotation);
        cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraHolderTransform.rotation = cameraRotationState.targetRotation;

        cameraRotationState.rotation = Vector3.zero;
        cameraRotationState.rotation.x = cameraRotationState.pivotAngle;

        cameraRotationState.targetRotation = Quaternion.Euler(cameraRotationState.rotation);
        cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.localRotation = cameraRotationState.targetRotation;
    }

    public void FocusedRotation()
    {
        cameraRotationState.velocity = 0;

        cameraRotationState.direction = 
            cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform.position - 
            cameraRotationState.playerWorker.player.transform.position;

        cameraRotationState.direction.Normalize();
        cameraRotationState.direction.y = 0;

        cameraRotationState.focusedTargetRotation = Quaternion.LookRotation(cameraRotationState.direction);
        cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraHolderTransform.rotation = cameraRotationState.focusedTargetRotation;

        cameraRotationState.direction = cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform.position -
            cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.position;
        
        cameraRotationState.direction.Normalize();

        cameraRotationState.focusedTargetRotation = Quaternion.LookRotation(cameraRotationState.direction);
        cameraRotationState.eulerAngles = cameraRotationState.focusedTargetRotation.eulerAngles;
        cameraRotationState.eulerAngles.y = 0;
        cameraRotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraPivotTransform.localEulerAngles = cameraRotationState.eulerAngles;
    }
}
