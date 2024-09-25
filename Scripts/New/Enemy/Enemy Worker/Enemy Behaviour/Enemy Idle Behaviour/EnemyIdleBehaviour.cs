using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleBehaviour : EnemyAIBehaviour
{
    public class IdleBehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyIdleBehaviourSettings idleBehaviourSettings;

        public IdleBehaviourState(EnemyWorker enemyWorker, EnemyIdleBehaviourSettings idleBehaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.idleBehaviourSettings = idleBehaviourSettings;
        }
    }

    public IdleBehaviourState idleBehaviourState;

    public EnemyIdleBehaviour(EnemyWorker enemyWorker) => idleBehaviourState = new IdleBehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings.idleBehaviourSettings);

    public override EnemyAIBehaviour Tick()
    {
        HandleBehaviourUpdates();
        if (!idleBehaviourState.enemyWorker.enemyVision.CheckRanges()) return HandleBehaviour();
        else return HandleUpgradeBehaviour();
    }

    public override void HandleBehaviourUpdates()
    {
        idleBehaviourState.enemyWorker.enemyCamera.RemoveFromPlayerCameraFocusQueue();
    }

    public override EnemyAIBehaviour HandleDowngradeBehaviour() => null;

    public override EnemyAIBehaviour HandleBehaviour()
    {
        idleBehaviourState.enemyWorker.enemyAnimation.UpdateAnimator(0, 0);
        return this;
    }

    public override EnemyAIBehaviour HandleUpgradeBehaviour()
    {
        idleBehaviourState.enemyWorker.enemyBar.barState.enemyHealthBar.ActivateHealthBar();
        return idleBehaviourState.enemyWorker.enemyBehaviour.behaviourState.chaseBehaviour;
    }
}
