using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementControl
{
    public class MovementControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControl.ControlState controlState;

        public PlayerControlSettings controlSettings;

        public float horizontal, vertical, moveAmount, mouseX, mouseY;

        public Vector2 movementInput, cameraInput;

        public MovementControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
        }

        public void InitializeMovementControlState(PlayerControl playerControl) => controlState = playerControl.controlState;
    }

    public MovementControlState movementControlState;

    public PlayerMovementControl(PlayerWorker playerWorker) => movementControlState = new MovementControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start() => SetMoveInput();

    public void Update() => MoveInput(Time.deltaTime);

    public void SetMoveInput()
    {
        movementControlState.controlState.inputActions.PlayerMovement.Movement.performed += inputActions => movementControlState.movementInput = inputActions.ReadValue<Vector2>();
        movementControlState.controlState.inputActions.PlayerMovement.Camera.performed += i => movementControlState.cameraInput = i.ReadValue<Vector2>();
    }

    public void MoveInput(float delta)
    {
        movementControlState.horizontal = movementControlState.movementInput.x;
        movementControlState.vertical = movementControlState.movementInput.y;
        movementControlState.moveAmount = Mathf.Clamp01(Mathf.Abs(movementControlState.horizontal) + Mathf.Abs(movementControlState.vertical));
        movementControlState.mouseX = movementControlState.cameraInput.x;
        movementControlState.mouseY = movementControlState.cameraInput.y;
    }
}
