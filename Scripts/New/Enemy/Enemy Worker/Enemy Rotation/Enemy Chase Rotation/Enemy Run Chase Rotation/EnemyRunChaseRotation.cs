using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRunChaseRotation
{
    public class RunChaseRotationState
    {
        public EnemyWorker enemyWorker;

        public EnemyRotationSettings rotationSettings;

        public Rigidbody rigidbody;

        public Vector3 direction, relativeDirection, targetVelocity;

        public Quaternion targetRotation;

        public float rotationSpeed;

        public RunChaseRotationState(EnemyWorker enemyWorker, EnemyRotationSettings rotationSettings)
        {
            this.enemyWorker = enemyWorker;
            this.rotationSettings = rotationSettings;
            rigidbody = rotationSettings.rigidbody;
            rotationSpeed = rotationSettings.rotationSpeed;
        }
    }

    public RunChaseRotationState runChaseRotationState;

    public EnemyRunChaseRotation(EnemyWorker enemyWorker) => runChaseRotationState = new RunChaseRotationState(enemyWorker, enemyWorker.enemyAI.enemySettings.rotationSettings);

    public void HandleRunChaseMovementRotation()
    {
        if (runChaseRotationState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting)
        {
            runChaseRotationState.direction = runChaseRotationState.enemyWorker.player.position - runChaseRotationState.enemyWorker.enemyAI.transform.position;
            runChaseRotationState.direction.y = 0;
            runChaseRotationState.direction.Normalize();

            if (runChaseRotationState.direction == Vector3.zero) runChaseRotationState.direction = runChaseRotationState.enemyWorker.enemyAI.transform.forward;

            runChaseRotationState.targetRotation = Quaternion.LookRotation(runChaseRotationState.direction);
            runChaseRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(runChaseRotationState.enemyWorker.enemyAI.transform.rotation, runChaseRotationState.targetRotation, runChaseRotationState.rotationSpeed / Time.deltaTime);
        }
        else
        {
            runChaseRotationState.relativeDirection = runChaseRotationState.enemyWorker.enemyAI.transform.InverseTransformDirection(runChaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.desiredVelocity);
            runChaseRotationState.targetVelocity = runChaseRotationState.rigidbody.velocity;

            runChaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.enabled = true;
            runChaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.SetDestination(runChaseRotationState.enemyWorker.player.position);
            runChaseRotationState.rigidbody.velocity = runChaseRotationState.targetVelocity;

            runChaseRotationState.enemyWorker.enemyAI.transform.rotation = Quaternion.Slerp(
                runChaseRotationState.enemyWorker.enemyAI.transform.rotation,
                runChaseRotationState.enemyWorker.enemyAgent.agentState.navMeshAgent.transform.rotation,
                runChaseRotationState.rotationSpeed / Time.deltaTime);
        }
    }
}
