using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRigidbodyMovement
{
    public class RigidbodyMovementState
    {
        public EnemyWorker enemyWorker;

        public EnemyMovementSettings movementSettings;

        public Rigidbody rigidbody;

        public Vector3 moveDirection, normalVector, projectedValocity;

        public float runMovementSpeed, damageMovementSpeed;

        public RigidbodyMovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;
            rigidbody = movementSettings.enemyRigidbodyMovementSettings.rigidbody;
            runMovementSpeed = movementSettings.enemyRigidbodyMovementSettings.runMovementSpeed;
            damageMovementSpeed = movementSettings.enemyRigidbodyMovementSettings.damageMovementSpeed;
        }
    }

    public RigidbodyMovementState rigidbodyMovementState;

    public EnemyRigidbodyMovement(EnemyWorker enemyWorker) => rigidbodyMovementState = new RigidbodyMovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);
    
    public void HandleRigidbodyMovement()
    {
        if (rigidbodyMovementState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting) return;

        rigidbodyMovementState.moveDirection = rigidbodyMovementState.enemyWorker.enemyAI.transform.forward;
        rigidbodyMovementState.moveDirection.Normalize();
        rigidbodyMovementState.moveDirection.y = 0;

        rigidbodyMovementState.moveDirection *= rigidbodyMovementState.runMovementSpeed;

        rigidbodyMovementState.projectedValocity = Vector3.ProjectOnPlane(rigidbodyMovementState.moveDirection, rigidbodyMovementState.normalVector);
        rigidbodyMovementState.rigidbody.velocity = rigidbodyMovementState.projectedValocity;
    }
}
