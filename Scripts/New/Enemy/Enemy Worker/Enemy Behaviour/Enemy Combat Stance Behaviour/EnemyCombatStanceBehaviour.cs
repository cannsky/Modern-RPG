using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatStanceBehaviour : EnemyAIBehaviour
{
    public class CombatStanceBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyCombatStanceBehaviourSettings combatStanceBehaviourSettings;

        public CombatStanceBehaviourState(EnemyWorker enemyWorker, EnemyCombatStanceBehaviourSettings combatStanceBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.combatStanceBehaviourSettings = combatStanceBehaviourSettings;
        }
    }

    public CombatStanceBehaviourState combatStanceBehaviourState;

    public EnemyCombatStanceBehaviour(EnemyWorker enemyWorker) => combatStanceBehaviourState = new CombatStanceBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.combatStanceBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        if (combatStanceBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isInteracting) return HandleBehaviour();
        else if (!combatStanceBehaviourState.enemyWorker.enemyVision.CheckAttackRange()) return HandleDowngradeBehaviour();
        else if (combatStanceBehaviourState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttackRecovering) return HandleBehaviour();
        else return HandleUpgradeBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {

    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour()
    {
        return combatStanceBehaviourState.enemyWorker.enemyBehaviour.behaviourState.chaseBehaviour;
    }

    public override EnemyAIBehaviour HandleBehaviour()
    {
        combatStanceBehaviourState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);
        if (Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking)
            return combatStanceBehaviourState.enemyWorker.enemyBehaviour.behaviourState.dodgeBehaviour;
        else return combatStanceBehaviourState.enemyWorker.enemyBehaviour.behaviourState.rotateBehaviour;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour()
    {
        return combatStanceBehaviourState.enemyWorker.enemyBehaviour.behaviourState.attackBehaviour;
    }
}
