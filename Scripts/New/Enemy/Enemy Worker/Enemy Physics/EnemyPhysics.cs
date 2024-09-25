using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhysics
{
    public class PhysicsState
    {
        public EnemyWorker enemyWorker;

        public EnemyPhysicsSettings physicsSettings;

        public EnemyGravityPhysics enemyGravityPhysics;

        public PhysicsState(EnemyWorker enemyWorker, EnemyPhysicsSettings physicsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.physicsSettings = physicsSettings;
            enemyGravityPhysics = new EnemyGravityPhysics(enemyWorker);
        }
    }

    public PhysicsState physicsState;

    public EnemyPhysics(EnemyWorker enemyWorker) => physicsState = new PhysicsState(enemyWorker, enemyWorker.enemyAI.enemySettings.physicsSettings);

    public void Start()
    {
        //physicsState.enemyWorker.enemyAgent.agentState.navMeshAgent.enabled = false;
        physicsState.enemyWorker.enemyRotation.rotationState.enemyChaseRotation.chaseRotationState.rigidbody.isKinematic = false;
    }

    public void FixedUpdate()
    {
        physicsState.enemyGravityPhysics.FixedUpdate();
    }
}
