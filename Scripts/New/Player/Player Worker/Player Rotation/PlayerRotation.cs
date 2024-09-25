using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation
{
    public class RotationState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerMovement.MovementState movementState;

        public Transform playerTransform, cameraTransform;

        public Quaternion tr, targetRotation;
        public Vector3 targetDirection, rotationDirection;

        public float rotationSpeed, moveOverride;

        public RotationState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
            cameraTransform = movementSettings.cameraTransform;
            rotationSpeed = movementSettings.rotationSpeed;
            playerTransform = playerWorker.player.transform;
        }

        public void InitializeRotationState(PlayerMovement playerMovement) => movementState = playerMovement.movementState;
    }

    public RotationState rotationState;

    public PlayerRotation(PlayerWorker playerWorker) => rotationState = new RotationState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void FixedUpdate() => HandleRotation(Time.deltaTime);

    public void HandleRotation(float delta)
    {
        if (!rotationState.playerWorker.playerAnimation.animationState.canRotate) return;
        else if (rotationState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform == null) NormalRotation(delta);
        else FocusedRotation();
    }

    public void FocusedRotation()
    {
        if (rotationState.playerWorker.playerControl.controlState.sprintFlag) Debug.Log(rotationState.playerWorker.playerControl.controlState.sprintFlag);
        if (rotationState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting || 
            rotationState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isRolling) ActionBasedFocusedRotation();
        else NormalFocusedRotation();
    }

    public void NormalFocusedRotation()
    {
        rotationState.rotationDirection = Vector3.zero;
        rotationState.rotationDirection = rotationState.movementState.playerRigidbodyMovement.rigidbodyMovementState.moveDirection;
        rotationState.rotationDirection =
            rotationState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform.position -
            rotationState.playerTransform.position;
        rotationState.rotationDirection.y = 0;
        rotationState.rotationDirection.Normalize();
        rotationState.tr = Quaternion.LookRotation(rotationState.rotationDirection);
        rotationState.targetRotation = Quaternion.Slerp(
            rotationState.playerTransform.rotation,
            rotationState.tr,
            rotationState.rotationSpeed * Time.deltaTime);
        rotationState.playerTransform.rotation = rotationState.targetRotation;
    }

    public void ActionBasedFocusedRotation()
    {
        rotationState.targetDirection = Vector3.zero;
        rotationState.targetDirection =
            rotationState.cameraTransform.forward *
            rotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.vertical;
        rotationState.targetDirection +=
            rotationState.cameraTransform.right *
            rotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.horizontal;
        rotationState.targetDirection.Normalize();
        rotationState.targetDirection.y = 0;

        if (rotationState.targetDirection == Vector3.zero) rotationState.targetDirection = rotationState.playerTransform.forward;

        rotationState.tr = Quaternion.LookRotation(rotationState.targetDirection);
        rotationState.targetRotation = Quaternion.Slerp(rotationState.playerTransform.rotation, rotationState.tr, rotationState.rotationSpeed * Time.deltaTime);

        rotationState.playerTransform.rotation = rotationState.targetRotation;
    }

    public void NormalRotation(float delta)
    {
        rotationState.targetDirection = Vector3.zero;
        rotationState.moveOverride = rotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.moveAmount;

        rotationState.targetDirection = rotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.forward * rotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.vertical;
        rotationState.targetDirection += rotationState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.right * rotationState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.horizontal;

        rotationState.targetDirection.Normalize();
        rotationState.targetDirection.y = 0;

        if (rotationState.targetDirection == Vector3.zero) rotationState.targetDirection = rotationState.playerTransform.forward;

        rotationState.tr = Quaternion.LookRotation(rotationState.targetDirection);
        rotationState.targetRotation = Quaternion.Slerp(rotationState.playerTransform.rotation, rotationState.tr, rotationState.rotationSpeed * delta);

        rotationState.playerTransform.rotation = rotationState.targetRotation;
    }
}
