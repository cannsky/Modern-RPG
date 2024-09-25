using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRootMotionStabilizer : MonoBehaviour
{
    public Animator animator;
    public EnemyAI enemyAI;
    public Rigidbody rb;

    private Vector3 deltaPosition, velocity;

    public void OnAnimatorMove()
    {
        animator.applyRootMotion = true;

        rb.drag = 0;
        deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        velocity = deltaPosition / Time.deltaTime;

        rb.velocity = !animator.GetCurrentAnimatorStateInfo(5).IsTag("Walk Backwards") ? velocity : velocity * 1.2f;

        if (enemyAI.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isRotateWithRootMotion)
        {
            enemyAI.transform.rotation *= animator.deltaRotation;
            enemyAI.enemyWorker.enemyAgent.ResetAgentTransform();
        }
    }
}
