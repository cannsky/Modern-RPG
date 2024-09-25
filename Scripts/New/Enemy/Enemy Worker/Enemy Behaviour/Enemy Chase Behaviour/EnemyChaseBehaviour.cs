using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : EnemyAIBehaviour
{
    public class ChaseBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyChaseBehaviourSettings chaseBehaviourSettings;

        public ChaseBehaviourState(EnemyWorker enemyWorker, EnemyChaseBehaviourSettings chaseBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.chaseBehaviourSettings = chaseBehaviourSettings;
        }
    }

    public ChaseBehaviourState chaseBehaviourState;

    public EnemyChaseBehaviour(EnemyWorker enemyWorker) => chaseBehaviourState = new ChaseBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.chaseBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        if (!chaseBehaviourState.enemyWorker.enemyVision.CheckRanges()) return HandleDowngradeBehaviour();
        else if (!chaseBehaviourState.enemyWorker.enemyVision.CheckAttackRange()) return HandleBehaviour();
        else return HandleUpgradeBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {
        chaseBehaviourState.enemyWorker.enemyCamera.AddToPlayerCameraFocusQueue();
    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour()
    {
        chaseBehaviourState.enemyWorker.enemyBar.barState.enemyHealthBar.DeactiveHealthBar();
        return chaseBehaviourState.enemyWorker.enemyBehaviour.behaviourState.idleBehaviour;
    }

    public override EnemyAIBehaviour HandleBehaviour()
    {
        chaseBehaviourState.enemyWorker.enemySFX.sfxState.enemySpeechSFX.PlayAudio(isBattleCry: true, isCustomLine: true);
        chaseBehaviourState.enemyWorker.enemyMovement.movementState.enemyChaseMovement.HandleChase();
        return this;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour()
    {
        return chaseBehaviourState.enemyWorker.enemyBehaviour.behaviourState.combatStanceBehaviour;
    }

}
