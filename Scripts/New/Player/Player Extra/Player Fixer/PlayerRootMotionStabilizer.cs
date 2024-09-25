using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRootMotionStabilizer : MonoBehaviour
{
    private Animator animator;
    private PlayerWorker playerWorker;
    private Vector3 deltaPosition, velocity;

    private int attackLayerIndex = 3, dodgeLayerIndex = 4, statsLayerIndex = 5;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerWorker = Player.Instance.playerWorker;
    }

    private void OnAnimatorMove()
    {
        if (!animator.GetCurrentAnimatorStateInfo(attackLayerIndex).IsTag("Attack") &&
            !animator.GetCurrentAnimatorStateInfo(dodgeLayerIndex).IsTag("Dodge") &&
            !animator.GetCurrentAnimatorStateInfo(statsLayerIndex).IsTag("Damage")) return;
        animator.applyRootMotion = true;
        playerWorker.playerMovement.movementState.playerRigidbodyMovement.rigidbodyMovementState.rigidbody.drag = 0;
        deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        velocity = deltaPosition / Time.deltaTime;
        if (animator.GetCurrentAnimatorStateInfo(attackLayerIndex).IsTag("Attack")) playerWorker.playerMovement.movementState.playerRigidbodyMovement.rigidbodyMovementState.rigidbody.velocity = velocity * (velocity.magnitude < 5f ? 2.5f : 1f);
        else playerWorker.playerMovement.movementState.playerRigidbodyMovement.rigidbodyMovementState.rigidbody.velocity = velocity;
    }
}
