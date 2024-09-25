using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics
{
    public class PhysicsState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerFootPlacementPhysics playerFootPlacementPhysics;

        public PlayerMovement.MovementState movementState;

        public Rigidbody rigidbody;
        public GameObject normalCamera;
        public Transform playerTransform;

        public RaycastHit fallHit;
        public LayerMask ignoreForGroundCheck;
        public Vector3 fallDirection, normalVector, targetPosition, lastPosition, fallTargetPosition, projectedValocity, fallVelocity, origin;

        public float fallingSpeed, groundDetectionRayStartPoint, minimumDistanceNeededToBeginFall, groundDirectionRayDistance, inAirTimer;

        public PhysicsState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
            rigidbody = movementSettings.rigidbody;
            fallingSpeed = movementSettings.fallingSpeed;
            groundDetectionRayStartPoint = movementSettings.groundDetectionRayStartPoint;
            minimumDistanceNeededToBeginFall = movementSettings.minimumDistanceNeededToBeginFall;
            groundDirectionRayDistance = movementSettings.groundDirectionRayDistance;
            playerTransform = playerWorker.player.transform;

            playerFootPlacementPhysics = new PlayerFootPlacementPhysics(playerWorker);
        }

        public void InitializeFallMovementState() => movementState = playerWorker.playerMovement.movementState;
    }

    public PhysicsState physicsState;

    public PlayerPhysics(PlayerWorker playerWorker) => physicsState = new PhysicsState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Start()
    {
        physicsState.ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
        physicsState.InitializeFallMovementState();
    }

    public void FixedUpdate() => HandleFalling();

    public void Update() => physicsState.playerFootPlacementPhysics.Update();

    public void HandleFalling()
    {
        physicsState.targetPosition = physicsState.playerTransform.position;
        physicsState.origin = physicsState.playerTransform.position;
        physicsState.origin.y += physicsState.groundDetectionRayStartPoint;

        if (Physics.Raycast(physicsState.origin, -Vector3.up, out physicsState.fallHit, 10f, LayerMask.GetMask("Ground")))
        {
            physicsState.fallTargetPosition = physicsState.fallHit.point;
            physicsState.targetPosition.y = physicsState.fallTargetPosition.y;
        }

        physicsState.playerTransform.position = Vector3.Lerp(physicsState.playerTransform.position, physicsState.targetPosition, Time.deltaTime * 25f);
    }
}
