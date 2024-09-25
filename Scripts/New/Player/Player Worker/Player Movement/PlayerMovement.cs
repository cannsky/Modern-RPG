using System.Collections;
using UnityEngine;

public class PlayerMovement
{
    public class MovementState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerAnimationMovement playerAnimationMovement;
        public PlayerAttackMovement playerAttackMovement;
        public PlayerRigidbodyMovement playerRigidbodyMovement;
        public PlayerRollMovement playerRollMovement;

        public MovementState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;

            playerAnimationMovement = new PlayerAnimationMovement(playerWorker);
            playerAttackMovement = new PlayerAttackMovement(playerWorker);
            playerRigidbodyMovement = new PlayerRigidbodyMovement(playerWorker);
            playerRollMovement = new PlayerRollMovement(playerWorker);
        }

        public void InitializeMovementState(PlayerMovement playerMovement)
        {
            playerAnimationMovement.animationMovementState.InitializeAnimationMovementState(playerMovement);
            playerRigidbodyMovement.rigidbodyMovementState.InitializeRigidbodyMovementState(playerMovement);
            playerRollMovement.rollMovementState.InitializeRollMovementState(playerMovement);
            playerMovement.movementState.playerWorker.playerRotation.rotationState.InitializeRotationState(playerMovement);
        }
    }

    public MovementState movementState;

    public PlayerMovement(PlayerWorker playerWorker) => movementState = new MovementState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Start()
    {
        movementState.InitializeMovementState(this);
    }

    public void Update()
    {
        if (movementState.playerWorker.playerStats.statsState.playerActionStats.CheckMovementAvailable()) MovementUpdate();
        else if (movementState.playerWorker.playerStats.statsState.playerActionStats.CheckAttackMovementAvailable()) AttackMovementUpdate();
    }

    public void FixedUpdate()
    {
        //if (movementState.playerWorker.playerStats.statsState.playerActionStats.CheckMovementAvailable()) MovementFixedUpdate();
        MovementFixedUpdate();
    }

    public void AttackMovementUpdate()
    {
        movementState.playerAttackMovement.Update();
    }

    public void MovementUpdate()
    {
        movementState.playerAnimationMovement.Update();
        movementState.playerRigidbodyMovement.Update();
        movementState.playerRollMovement.Update();
    }

    public void MovementFixedUpdate()
    {

    }
}
