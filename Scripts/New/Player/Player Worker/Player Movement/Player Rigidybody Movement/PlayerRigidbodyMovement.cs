using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyMovement
{
    public class RigidybodyMovementState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerMovement.MovementState movementState;

        public Rigidbody rigidbody;

        public Vector3 moveDirection, normalVector, projectedValocity;

        public float runMovementSpeed, sprintMovementSpeed, speed;

        public RigidybodyMovementState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
            rigidbody = movementSettings.rigidbody;
            runMovementSpeed = movementSettings.runMovementSpeed;
            sprintMovementSpeed = movementSettings.sprintMovementSpeed;
        }

        public void InitializeRigidbodyMovementState(PlayerMovement playerMovement) => movementState = playerMovement.movementState;
    }

    public RigidybodyMovementState rigidbodyMovementState;

    public PlayerRigidbodyMovement(PlayerWorker playerWorker) => rigidbodyMovementState = new RigidybodyMovementState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Update() => HandleMovement();

    public void HandleMovement()
    {
        if (rigidbodyMovementState.playerWorker.playerControl.controlState.rollFlag) return;

        if (rigidbodyMovementState.playerWorker.playerControl.controlState.isInteracting) return;

        rigidbodyMovementState.moveDirection = 
            rigidbodyMovementState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.forward * 
            rigidbodyMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.vertical;
        rigidbodyMovementState.moveDirection += 
            rigidbodyMovementState.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.right * 
            rigidbodyMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.horizontal;

        if (rigidbodyMovementState.playerWorker.playerUI.CheckUIOpened()) rigidbodyMovementState.moveDirection = Vector3.zero;

        rigidbodyMovementState.moveDirection.Normalize();
        rigidbodyMovementState.moveDirection.y = 0;

        if (rigidbodyMovementState.moveDirection.magnitude != 0) rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isMoving = true;
        else rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isMoving = false;

        rigidbodyMovementState.speed = rigidbodyMovementState.runMovementSpeed;

        if (rigidbodyMovementState.playerWorker.playerControl.controlState.sprintFlag && 
            rigidbodyMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.moveAmount > 0.5f &&
            rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.CheckEnergyUsageAvailable())
        {
            rigidbodyMovementState.speed = rigidbodyMovementState.sprintMovementSpeed;
            rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting = true;
            rigidbodyMovementState.moveDirection *= rigidbodyMovementState.speed;
            rigidbodyMovementState.playerWorker.playerStats.statsState.playerEnergyStats.DecreaseEnergy();
        }
        else
        {
            if (rigidbodyMovementState.playerWorker.playerControl.controlState.playerMovementControl.movementControlState.moveAmount < 0.5f)
            {
                rigidbodyMovementState.moveDirection *= rigidbodyMovementState.runMovementSpeed;
                rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting = false;
            }
            else
            {
                rigidbodyMovementState.moveDirection *= rigidbodyMovementState.speed;
                rigidbodyMovementState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting = false;
            }
        }

        rigidbodyMovementState.projectedValocity = Vector3.ProjectOnPlane(rigidbodyMovementState.moveDirection, rigidbodyMovementState.normalVector);

        rigidbodyMovementState.rigidbody.velocity = rigidbodyMovementState.projectedValocity;
    }
}
