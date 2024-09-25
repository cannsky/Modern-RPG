using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollMovement
{
    public class RollMovementState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerMovement.MovementState movementState;

        public Transform playerTransform;

        public Quaternion rollRotation;

        public RollMovementState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
            playerTransform = playerWorker.player.transform;
        }

        public void InitializeRollMovementState(PlayerMovement playerMovement) => movementState = playerMovement.movementState;

    }

    public RollMovementState rollMovementState;

    public PlayerRollMovement(PlayerWorker playerWorker) => rollMovementState = new RollMovementState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Update() => HandleRolling();

    public void HandleRolling()
    {
        if (rollMovementState.playerWorker.playerAnimation.animationState.animators[0].GetBool("isInteracting") || 
            !rollMovementState.playerWorker.playerControl.controlState.rollFlag ||
            rollMovementState.playerWorker.playerStats.statsState.playerEnergyStats.energyStatsState.currentEnergy <
            rollMovementState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.rollEnergyDecreaseMultiplier) return;
        
        rollMovementState.movementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isRolling = true;
        rollMovementState.movementState.playerRigidbodyMovement.rigidbodyMovementState.moveDirection = rollMovementState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.forward * 
            rollMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.vertical;
        rollMovementState.movementState.playerRigidbodyMovement.rigidbodyMovementState.moveDirection += rollMovementState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.right * 
            rollMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.horizontal;
        rollMovementState.playerWorker.playerStance.ChangeToAggressiveStance();
        rollMovementState.playerWorker.playerStats.statsState.playerEnergyStats.DecreaseEnergy();
        if (rollMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.moveAmount > 0) RollFront();
        else RollBack();
    }

    public void RollFront()
    {
        rollMovementState.playerWorker.playerAnimation.PlayTargetAnimation("Roll", true);
        rollMovementState.movementState.playerRigidbodyMovement.rigidbodyMovementState.moveDirection.y = 0;
        rollMovementState.rollRotation = Quaternion.LookRotation(rollMovementState.movementState.playerRigidbodyMovement.rigidbodyMovementState.moveDirection);
        rollMovementState.playerTransform.rotation = rollMovementState.rollRotation;
    }

    public void RollBack()
    {
        rollMovementState.playerWorker.playerAnimation.PlayTargetAnimation("Rollback", true);
    }
}
