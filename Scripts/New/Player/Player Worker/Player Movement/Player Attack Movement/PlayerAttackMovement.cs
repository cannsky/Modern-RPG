using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMovement
{
    public class AttackMovementState
    {
        public PlayerWorker playerWorker;

        public PlayerMovementSettings movementSettings;

        public PlayerMovement.MovementState movementState;

        public Rigidbody rigidbody;

        public Vector3 moveDirection, normalVector, projectedValocity;

        public float attackMovementSpeed;

        public AttackMovementState(PlayerWorker playerWorker, PlayerMovementSettings movementSettings)
        {
            this.playerWorker = playerWorker;
            this.movementSettings = movementSettings;
            rigidbody = movementSettings.rigidbody;
            attackMovementSpeed = movementSettings.attackMovementSpeed;
        }

        public void InitializeRigidbodyMovementState(PlayerMovement playerMovement) => movementState = playerMovement.movementState;
    }

    public AttackMovementState attackMovementState;

    public PlayerAttackMovement(PlayerWorker playerWorker) => attackMovementState = new AttackMovementState(playerWorker, playerWorker.player.playerSettings.movementSettings);

    public void Update() => HandleAttackMovement();

    public void HandleAttackMovement()
    {
        return;
        Debug.Log("zuhahahaha!");
        attackMovementState.moveDirection = attackMovementState.playerWorker.player.transform.forward * 1f;
        attackMovementState.moveDirection.Normalize();
        attackMovementState.moveDirection.y = 0;
        attackMovementState.moveDirection *= attackMovementState.attackMovementSpeed;
        attackMovementState.projectedValocity = Vector3.ProjectOnPlane(attackMovementState.moveDirection, attackMovementState.normalVector);
        attackMovementState.rigidbody.velocity = attackMovementState.projectedValocity;
    }
}
