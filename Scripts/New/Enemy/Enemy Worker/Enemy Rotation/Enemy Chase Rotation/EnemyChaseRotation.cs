using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseRotation
{
    public class ChaseRotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public EnemyRunChaseRotation enemyRunChaseRotation;
        public EnemyStrafeChaseRotation enemyStrafeChaseRotation;

        public Rigidbody rigidbody;

        public Vector3 direction, relativeDirection, targetVelocity;

        public Quaternion targetRotation;

        public float rotationSpeed;

        public ChaseRotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            enemyRunChaseRotation = new EnemyRunChaseRotation(enemyWorker);
            enemyStrafeChaseRotation = new EnemyStrafeChaseRotation(enemyWorker);
            rigidbody = rotationSettings.rigidbody;
            rotationSpeed = rotationSettings.rotationSpeed;
        }
    }

    public ChaseRotationState chaseRotationState;

    public EnemyChaseRotation(EnemyWorker enemyWorker) => chaseRotationState = new ChaseRotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);

    public void HandleRunChaseMovementRotation()
    {
        if (chaseRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting)
        {
            chaseRotationState.direction = chaseRotationState.enemyWorker.player.position - chaseRotationState.enemyWorker.enemyAI.transform.position;
            chaseRotationState.direction.y = 0;
            chaseRotationState.direction.Normalize();

            if (chaseRotationState.direction == Vector3.zero) chaseRotationState.direction = chaseRotationState.enemyWorker.enemyAI.transform.forward;

            chaseRotationState.targetRotation = Quaternion.LookRotation(chaseRotationState.direction);
            chaseRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(chaseRotationState.enemyWorker.enemyAI.transform.rotation, chaseRotationState.targetRotation, chaseRotationState.rotationSpeed / Time.deltaTime);
        }
        else
        {
            chaseRotationState.relativeDirection = chaseRotationState.enemyWorker.enemyAI.transform.InverseTransformDirection(chaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.desiredVelocity);
            chaseRotationState.targetVelocity = chaseRotationState.rigidbody.velocity;

            chaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.enabled = true;
            chaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.SetDestination(chaseRotationState.enemyWorker.player.position);
            chaseRotationState.rigidbody.velocity = chaseRotationState.targetVelocity;

            chaseRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(
                chaseRotationState.enemyWorker.enemyAI.transform.rotation,
                chaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.transform.rotation,
                chaseRotationState.rotationSpeed / Time.deltaTime);
        }
    }
}
