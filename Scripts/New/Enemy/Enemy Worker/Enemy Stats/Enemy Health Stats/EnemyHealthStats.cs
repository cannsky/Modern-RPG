using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthStats
{
    public class HealthStatsState
    {
        public EnemyWorker enemyWorker;

        public EnemyStatsSettings statsSettings;

        public int healthLevel;

        public float maxHealth, currentHealth;

        public HealthStatsState(EnemyWorker enemyWorker, EnemyStatsSettings statsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.statsSettings = statsSettings;
            healthLevel = statsSettings.healthStatsSettings.healthLevel;
            maxHealth = statsSettings.healthStatsSettings.healthLevel * statsSettings.healthStatsSettings.healthLevelMultiplier;
            currentHealth = maxHealth;
        }
    }

    public HealthStatsState healthStatsState;

    public EnemyHealthStats(EnemyWorker enemyWorker) => healthStatsState = new HealthStatsState(enemyWorker, enemyWorker.enemyAI.enemySettings.statsSettings);

    public void Start() => OnHealthChanged();

    public void Update() => HealthRegeneration();

    public void TakeDamage(float damage)
    {
        healthStatsState.currentHealth -= damage;
        OnHealthChanged();
    }

    public void Revive()
    {
        healthStatsState.currentHealth = healthStatsState.maxHealth;
        healthStatsState.enemyWorker.enemyAnimation.PlayTargetAnimation("Revive 1", true);
        OnHealthChanged();
    }

    public void OnHealthChanged() => healthStatsState.enemyWorker.enemyBar.barState.enemyHealthBar.UpdateHealthBarFillStatus();

    public void HealthRegeneration()
    {
        if (healthStatsState.currentHealth <= healthStatsState.maxHealth)
        {
            healthStatsState.currentHealth += healthStatsState.enemyWorker.enemyStats.statsState.enemyMultiplierStats.multiplierStatsState.healthRegenerationMultiplier * Time.deltaTime;
            if (healthStatsState.currentHealth > healthStatsState.maxHealth) healthStatsState.currentHealth = healthStatsState.maxHealth;
            OnHealthChanged();
        }
    }
}
