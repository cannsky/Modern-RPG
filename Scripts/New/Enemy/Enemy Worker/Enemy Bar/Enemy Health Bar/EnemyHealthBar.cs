using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar
{
    public class HealthBarState
    {
        public EnemyWorker enemyWorker;

        public EnemyBarSettings barSettings;

        public GameObject healthBarGameObject;

        public Image healthBarFillImage;

        public HealthBarState(EnemyWorker enemyWorker, EnemyBarSettings barSettings)
        {
            this.enemyWorker = enemyWorker;
            this.barSettings = barSettings;
            healthBarGameObject = barSettings.healthBarSettings.healthBarGameObject;
            healthBarFillImage = barSettings.healthBarSettings.healthBarFillImage;
        }
    }

    public HealthBarState healthBarState;

    public EnemyHealthBar(EnemyWorker enemyWorker) => healthBarState = new HealthBarState(enemyWorker, enemyWorker.enemyAI.enemySettings.barSettings);

    public void LateUpdate() => RotateHealthBarToPlayer();

    public void ActivateHealthBar() => healthBarState.healthBarGameObject.SetActive(true);

    public void DeactiveHealthBar() => healthBarState.healthBarGameObject.SetActive(false);

    public void UpdateHealthBarFillStatus()
    {
        healthBarState.healthBarFillImage.fillAmount = (float)(healthBarState.enemyWorker.enemyStats.statsState.enemyHealthStats.healthStatsState.currentHealth /
            healthBarState.enemyWorker.enemyStats.statsState.enemyHealthStats.healthStatsState.maxHealth);
    }

    public void RotateHealthBarToPlayer()
    {
        if(healthBarState.healthBarGameObject.activeSelf) healthBarState.healthBarGameObject.transform.forward = Player.Instance.playerWorker.playerCamera.cameraState.playerCameraFollow.cameraFollowState.cameraTransform.forward;
    }
}
