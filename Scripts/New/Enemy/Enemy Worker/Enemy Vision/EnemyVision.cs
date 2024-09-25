using UnityEngine;

public class EnemyVision
{
    public class VisionState
    {
        public EnemyWorker enemyWorker;

        public bool playerInSightRange;
        public bool playerInCautionRange;
        public bool playerInAttackRange;
        public float playerDistance;

        public EnemyVisionSettings visionSettings;

        public VisionState(EnemyWorker enemyWorker, EnemyVisionSettings visionSettings)
        {
            this.enemyWorker = enemyWorker;
            this.visionSettings = visionSettings;
        }

        public bool UpdateVisionState(bool isReturnAttackRange = false, bool isReturnCautionRange = false)
        {
            playerInAttackRange = Physics.CheckSphere(enemyWorker.enemyAI.transform.position, visionSettings.attackRange, visionSettings.playerLayer);
            playerInCautionRange = Physics.CheckSphere(enemyWorker.enemyAI.transform.position, visionSettings.cautionRange, visionSettings.playerLayer);
            playerInSightRange = Physics.CheckSphere(enemyWorker.enemyAI.transform.position, visionSettings.sightRange, visionSettings.playerLayer);
            playerDistance = Helper.CalculateDistance(enemyWorker.enemyAI.transform.position, Player.Instance.transform.position);
            if (Player.Instance.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isDead) return false;
            else if (isReturnAttackRange) return playerInAttackRange;
            else if (isReturnCautionRange) return playerInCautionRange;
            else return playerInSightRange || playerInAttackRange;
        }
    }

    public VisionState visionState;

    public EnemyVision(EnemyWorker enemyWorker) => visionState = new VisionState(enemyWorker, enemyWorker.enemyAI.enemySettings.visionSettings);

    public bool CheckRanges() => visionState.UpdateVisionState();

    public bool CheckAttackRange() => visionState.UpdateVisionState(isReturnAttackRange: true);

    public bool CheckCautionRange() => visionState.UpdateVisionState(isReturnCautionRange: true);
}
