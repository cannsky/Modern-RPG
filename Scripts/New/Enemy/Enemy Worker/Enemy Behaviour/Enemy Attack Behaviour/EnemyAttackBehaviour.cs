using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackBehaviour : EnemyAIBehaviour
{
    public class AttackBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyAttackBehaviourSettings attackBehaviourSettings;

        public List<EnemyAttackBehaviourSettings.AttackBehaviour> attackBehaviours;

        public EnemyAttackBehaviourSettings.AttackBehaviour currentAttackBehaviour;

        public Vector3 distanceFromTarget, targetDirection;

        public float viewableAngle;

        public int maxChance, randomValue, tempChance;

        public AttackBehaviourState(EnemyWorker enemyWorker, EnemyAttackBehaviourSettings attackBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.attackBehaviourSettings = attackBehaviourSettings;
            attackBehaviours = attackBehaviourSettings.attackBehaviours;
        }
    }

    public AttackBehaviourState attackBehaviourState;

    public EnemyAttackBehaviour(EnemyWorker enemyWorker) => attackBehaviourState = new AttackBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.attackBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        if (attackBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isReviving) return HandleDowngradeBehaviour();
        else return HandleBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {
        
    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour()
    {
        return attackBehaviourState.enemyWorker.enemyBehaviour.behaviourState.combatStanceBehaviour;
    }

    public override EnemyAIBehaviour HandleBehaviour()
    {
        attackBehaviourState.enemyWorker.enemyAttack.HandleAttack();
        return HandleDowngradeBehaviour();
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour() => null;

    public void GetAttackBehaviour()
    {
        attackBehaviourState.targetDirection = attackBehaviourState.enemyWorker.player.position - attackBehaviourState.enemyWorker.enemyAI.transform.position;
        attackBehaviourState.viewableAngle = Vector3.Angle(attackBehaviourState.targetDirection, attackBehaviourState.enemyWorker.enemyAI.transform.forward);
        attackBehaviourState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.distanceFromTarget =
            Vector3.Distance(attackBehaviourState.enemyWorker.player.position, attackBehaviourState.enemyWorker.enemyAI.transform.position);

        attackBehaviourState.maxChance = 0;

        CalculateAttackLoop(false);

        attackBehaviourState.randomValue = Random.Range(0, attackBehaviourState.maxChance);
        attackBehaviourState.tempChance = 0;

        CalculateAttackLoop(true);

        if (attackBehaviourState.currentAttackBehaviour == null) attackBehaviourState.currentAttackBehaviour = attackBehaviourState.attackBehaviours[0];
    }

    public void CalculateAttackLoop(bool isMaxScoreCalculated)
    {
        foreach (EnemyAttackBehaviourSettings.AttackBehaviour attackBehaviour in attackBehaviourState.attackBehaviours)
        {
            if (attackBehaviourState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.distanceFromTarget <= attackBehaviour.maximumDistanceNeededToAttack &&
                attackBehaviourState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.chaseMovementState.distanceFromTarget >= attackBehaviour.minimumDistanceNeededToAttack)
            {
                if (attackBehaviourState.viewableAngle <= attackBehaviour.maximumAttackAngle && attackBehaviourState.viewableAngle >= attackBehaviour.minimumAttackAngle)
                {
                    if (!isMaxScoreCalculated) AddToMaxScore(attackBehaviour);
                    else DecideAttackBehaviour(attackBehaviour);
                }
            }
        }
    }

    public void AddToMaxScore(EnemyAttackBehaviourSettings.AttackBehaviour attackBehaviour) => attackBehaviourState.maxChance += attackBehaviour.attackChance;

    public void DecideAttackBehaviour(EnemyAttackBehaviourSettings.AttackBehaviour attackBehaviour)
    {
        if (attackBehaviourState.currentAttackBehaviour != null) return;

        attackBehaviourState.tempChance += attackBehaviour.attackChance;

        if(attackBehaviourState.tempChance > attackBehaviourState.randomValue) attackBehaviourState.currentAttackBehaviour = attackBehaviour;
    }
}
