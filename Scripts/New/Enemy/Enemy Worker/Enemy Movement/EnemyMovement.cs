using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement
{
    public class MovementState
    {
        public EnemyWorker enemyWorker;

        public Vector3 walkPoint;
        public bool walkPointSet;
        public Vector3 distanceBetweenLastPoint;
        public Vector3 distanceToWalkPoint;

        public EnemyMovementSettings movementSettings;

        public EnemyChaseMovement enemyChaseMovement;
        public EnemyPivotMovement enemyPivotMovement;
        public EnemyRigidbodyMovement enemyRigidbodyMovement;

        public MovementState(EnemyWorker enemyWorker, EnemyMovementSettings movementSettings)
        {
            this.enemyWorker = enemyWorker;
            this.movementSettings = movementSettings;

            enemyChaseMovement = new EnemyChaseMovement(enemyWorker);
            enemyPivotMovement = new EnemyPivotMovement(enemyWorker);
            enemyRigidbodyMovement = new EnemyRigidbodyMovement(enemyWorker);
        }
    }

    public MovementState movementState;

    public EnemyMovement(EnemyWorker enemyWorker) => movementState = new MovementState(enemyWorker, enemyWorker.enemyAI.enemySettings.movementSettings);

    public void Patrol() => Patrolling();

    public void Chase() => ChasePlayer();

    public void SearchWalkPoint()
    {
        /*
        movementState.walkPoint = new Vector3(
            movementState.enemyWorker.enemyAI.transform.position.x +
            Random.Range(-movementState.movementSettings.walkPointRange, movementState.movementSettings.walkPointRange),
            movementState.enemyWorker.enemyAI.transform.position.y,
            movementState.enemyWorker.enemyAI.transform.position.z +
            Random.Range(-movementState.movementSettings.walkPointRange, movementState.movementSettings.walkPointRange));
        movementState.walkPointSet = true;
        */
    }

    public void UpdateComponents()
    {
        movementState.enemyWorker.enemyAI.enemyWorker.enemyCamera.RemoveFromPlayerCameraFocusQueue();
        movementState.enemyWorker.enemyAgent.agentState.navMeshAgent.isStopped = false;
        //movementState.enemyWorker.enemyAI.enemyWorker.enemyAnimation.animationState.SetEnemyAnimatorState(new List<string>() { "Walk" });
    }

    public void MoveEnemy()
    {
        if (!movementState.walkPointSet) SearchWalkPoint();
        if (movementState.walkPointSet) movementState.enemyWorker.enemyAgent.agentState.navMeshAgent.SetDestination(movementState.walkPoint);
    }

    public void CheckDistance()
    {
        movementState.distanceBetweenLastPoint = movementState.distanceToWalkPoint;
        movementState.distanceToWalkPoint = movementState.enemyWorker.enemyAI.transform.position - movementState.walkPoint;
        if (movementState.distanceToWalkPoint.magnitude < 1f ||
            movementState.distanceToWalkPoint.magnitude == movementState.distanceBetweenLastPoint.magnitude) movementState.walkPointSet = false;
    }

    public void Patrolling()
    {
        UpdateComponents();
        MoveEnemy();
        CheckDistance();
    }

    public void ChasePlayer()
    {
        movementState.enemyWorker.enemyAI.enemyWorker.enemyCamera.AddToPlayerCameraFocusQueue();
        movementState.enemyWorker.enemyAgent.agentState.navMeshAgent.isStopped = false;
        //movementState.enemyWorker.enemyAI.enemyWorker.enemyAnimation.animationState.SetEnemyAnimatorState(new List<string>() { "Walk" });
        movementState.enemyWorker.enemyAgent.agentState.navMeshAgent.SetDestination(Player.Instance.transform.position);
    }
}