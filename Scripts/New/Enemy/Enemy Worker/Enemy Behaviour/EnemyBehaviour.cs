using UnityEngine;

public class EnemyBehaviour
{
    public class BehaviourState
    {
        public EnemyWorker enemyWorker;

        public EnemyBehaviourSettings behaviourSettings;

        public EnemyAIBehaviour currentAIBehaviour, nextAIBehaviour;

        public EnemyAttackBehaviour attackBehaviour;
        public EnemyChaseBehaviour chaseBehaviour;
        public EnemyCombatStanceBehaviour combatStanceBehaviour;
        public EnemyDodgeBehaviour dodgeBehaviour;
        public EnemyIdleBehaviour idleBehaviour;
        public EnemyRotateBehaviour rotateBehaviour;

        public BehaviourState(EnemyWorker enemyWorker, EnemyBehaviourSettings behaviourSettings)
        {
            this.enemyWorker = enemyWorker;
            this.behaviourSettings = behaviourSettings;
            attackBehaviour = new EnemyAttackBehaviour(enemyWorker);
            chaseBehaviour = new EnemyChaseBehaviour(enemyWorker);
            combatStanceBehaviour = new EnemyCombatStanceBehaviour(enemyWorker);
            dodgeBehaviour = new EnemyDodgeBehaviour(enemyWorker);
            idleBehaviour = new EnemyIdleBehaviour(enemyWorker);
            rotateBehaviour = new EnemyRotateBehaviour(enemyWorker);
            currentAIBehaviour = idleBehaviour;
        }
    }

    public BehaviourState behaviourState;

    public EnemyBehaviour(EnemyWorker enemyWorker) => behaviourState = new BehaviourState(enemyWorker, enemyWorker.enemyAI.enemySettings.behaviourSettings);

    public void Update() => UpdateBehaviour();

    public void UpdateBehaviour()
    {
        behaviourState.nextAIBehaviour = behaviourState.currentAIBehaviour.Tick();
        behaviourState.currentAIBehaviour = behaviourState.nextAIBehaviour;
    }
}
