using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGravityPhysics
{
    public class GravityPhysicsState
    {
        public EnemyWorker enemyWorker;

        public EnemyPhysicsSettings enemyPhysicsSettings;

        public Rigidbody rigidbody;
        public GameObject normalCamera;
        public Transform enemyTransform;

        public RaycastHit fallHit;
        public LayerMask ignoreForGroundCheck;
        public Vector3 fallDirection, normalVector, targetPosition, fallTargetPosition, projectedValocity, fallVelocity, origin, moveDirection;

        public float fallingSpeed, runMovementSpeed, groundDetectionRayStartPoint, minimumDistanceNeededToBeginFall, groundDirectionRayDistance, inAirTimer;
        public bool isInAir, isGrounded;

        public GravityPhysicsState(EnemyWorker enemyWorker, EnemyPhysicsSettings enemyPhysicsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.enemyPhysicsSettings = enemyPhysicsSettings;
            rigidbody = enemyPhysicsSettings.rigidbody;
            fallingSpeed = enemyPhysicsSettings.fallingSpeed;
            groundDetectionRayStartPoint = enemyPhysicsSettings.groundDetectionRayStartPoint;
            minimumDistanceNeededToBeginFall = enemyPhysicsSettings.minimumDistanceNeededToBeginFall;
            groundDirectionRayDistance = enemyPhysicsSettings.groundDirectionRayDistance;
            enemyTransform = enemyWorker.enemyAI.transform;
        }
    }

    public GravityPhysicsState gravityPhysicsState;

    public EnemyGravityPhysics(EnemyWorker enemyWorker) => gravityPhysicsState = new GravityPhysicsState(enemyWorker, enemyWorker.enemyAI.enemySettings.physicsSettings);

    public void Start()
    {
        gravityPhysicsState.isGrounded = true;
        gravityPhysicsState.ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
    }

    public void FixedUpdate() => HandleGravity();

    public void HandleGravity()
    {
        gravityPhysicsState.isGrounded = false;
        gravityPhysicsState.origin = gravityPhysicsState.enemyTransform.position;
        gravityPhysicsState.origin.y += gravityPhysicsState.groundDetectionRayStartPoint;
        if (Physics.Raycast(gravityPhysicsState.origin, gravityPhysicsState.enemyTransform.forward, out gravityPhysicsState.fallHit, 0.4f))
        {
            gravityPhysicsState.moveDirection = Vector3.zero;
        }

        if (gravityPhysicsState.isInAir)
        {
            gravityPhysicsState.rigidbody.AddForce(-Vector3.up * gravityPhysicsState.fallingSpeed);
            gravityPhysicsState.rigidbody.AddForce(gravityPhysicsState.moveDirection * gravityPhysicsState.fallingSpeed / 10f);
        }

        gravityPhysicsState.fallDirection = gravityPhysicsState.moveDirection;
        gravityPhysicsState.fallDirection.Normalize();
        gravityPhysicsState.origin = gravityPhysicsState.origin + gravityPhysicsState.fallDirection * gravityPhysicsState.groundDirectionRayDistance;
        gravityPhysicsState.targetPosition = gravityPhysicsState.enemyTransform.position;

        if (Physics.Raycast(gravityPhysicsState.origin, -Vector3.up, out gravityPhysicsState.fallHit, 10f))
        {
            gravityPhysicsState.normalVector = gravityPhysicsState.fallHit.normal;
            gravityPhysicsState.fallTargetPosition = gravityPhysicsState.fallHit.point;
            gravityPhysicsState.isGrounded = true;
            gravityPhysicsState.targetPosition.y = gravityPhysicsState.fallTargetPosition.y;

            if (gravityPhysicsState.isInAir)
            {
                if (gravityPhysicsState.inAirTimer > 0.5f)
                {

                }
                else
                {
                    gravityPhysicsState.inAirTimer = 0f;
                }
                gravityPhysicsState.isInAir = false;
            }
        }
        else
        {
            if (gravityPhysicsState.isGrounded) gravityPhysicsState.isGrounded = false;

            if (!gravityPhysicsState.isInAir)
            {
                gravityPhysicsState.fallVelocity = gravityPhysicsState.rigidbody.velocity;
                gravityPhysicsState.fallVelocity.Normalize();
                gravityPhysicsState.rigidbody.velocity = gravityPhysicsState.fallVelocity * (gravityPhysicsState.runMovementSpeed / 2);
                gravityPhysicsState.isInAir = true;
            }
        }

        gravityPhysicsState.enemyTransform.position = gravityPhysicsState.targetPosition;
    }
}
