using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath
{
    public class DeathState
    {
        public EnemyWorker enemyWorker;

        public EnemyDeathSettings deathSettings;

        public bool isPlayerCameraUpdated;

        public DeathState(EnemyWorker enemyWorker, EnemyDeathSettings deathSettings)
        {
            this.enemyWorker = enemyWorker;
            this.deathSettings = deathSettings;
        }
    }

    public DeathState deathState;

    public EnemyDeath(EnemyWorker enemyWorker) => deathState = new DeathState(enemyWorker, enemyWorker.enemyAI.enemySettings.deathSettings);

    public void OnDeath()
    {
        deathState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDead = true;
        deathState.enemyWorker.enemyAnimation.PlayTargetAnimation("Death 1", true);
        deathState.enemyWorker.enemyCamera.RemoveFromPlayerCameraFocusQueue();
        deathState.enemyWorker.enemyBar.barState.enemyHealthBar.DeactiveHealthBar();
        deathState.enemyWorker.enemyAI.enemyWorker.enemySpeech.PlaySpeech(3);
        deathState.enemyWorker.enemyMaterial.Dissolve();
    }
}