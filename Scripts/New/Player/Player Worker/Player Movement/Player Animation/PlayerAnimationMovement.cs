using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMovement
{
    public class AnimationMovementState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerMovement.MovementState movementState;

        public AnimationMovementState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
        }

        public void InitializeAnimationMovementState(PlayerMovement playerMovement) => movementState = playerMovement.movementState;
    }

    public AnimationMovementState animationMovementState;

    public PlayerAnimationMovement(PlayerWorker playerWorker) => animationMovementState = new AnimationMovementState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Update() => UpdateAnimator();

    public void UpdateAnimator()
    {
        if (animationMovementState.playerWorker.playerCamera.cameraState.playerCameraFocus.cameraFocusState.lockTransform == null &&
            !animationMovementState.playerWorker.playerControl.controlState.sprintFlag)
            animationMovementState.playerWorker.playerAnimation.UpdateAnimator(animationMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.moveAmount, 0);
        else animationMovementState.playerWorker.playerAnimation.UpdateAnimator(
            animationMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.vertical,
            animationMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.horizontal
            );
    }
}
