using System.Collections;
using UnityEngine;

public class EnemyDetection
{
    public class DetectionState
    {
        public EnemyWorker enemyWorker;

        public bool isCooldownEnded = true;
        public bool isPlayerFound = false;

        public EnemyDetectionSettings detectionSettings;

        public DetectionState(EnemyWorker enemyWorker, EnemyDetectionSettings detectionSettings)
        {
            this.enemyWorker = enemyWorker;
            this.detectionSettings = detectionSettings;
        }

        public void ResetState()
        {
            isCooldownEnded = false;
            isPlayerFound = false;
        }

    }

    public DetectionState detectionState;

    public EnemyDetection(EnemyWorker enemyWorker) => detectionState = new DetectionState(enemyWorker, enemyWorker.enemyAI.enemySettings.detectionSettings);

    public IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(detectionState.detectionSettings.raycastWaitTime);
        detectionState.isCooldownEnded = true;
    }

    public void SearchPlayer()
    {
        if (!detectionState.isCooldownEnded) return;
        if (ScanArea()) detectionState.isPlayerFound = true;
        else detectionState.isPlayerFound = false;
        detectionState.isCooldownEnded = false;
        detectionState.enemyWorker.enemyAI.StartCoroutine(ResetCooldown());
    }

    public bool ScanArea()
    {
        int threshold = detectionState.detectionSettings.raycastAngleThreshold;
        RaycastHit hit;
        for (int i = -threshold; i < threshold; i++)
        {
            if (Physics.Raycast(new Vector3(detectionState.enemyWorker.enemyAI.transform.position.x, detectionState.enemyWorker.enemyAI.transform.position.y + 1f,
                detectionState.enemyWorker.enemyAI.transform.position.z), Quaternion.Euler(0f, i, 0f) * detectionState.enemyWorker.enemyAI.transform.forward,
                out hit, 20, detectionState.detectionSettings.playerLayer)) return true;
            Debug.DrawRay(new Vector3(detectionState.enemyWorker.enemyAI.transform.position.x, detectionState.enemyWorker.enemyAI.transform.position.y + 1f, 
                detectionState.enemyWorker.enemyAI.transform.position.z), Quaternion.Euler(0, i, 0) * detectionState.enemyWorker.enemyAI.transform.forward, 
                Color.green, 1f);
        }
        return false;
    }

}
