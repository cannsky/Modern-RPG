using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthStats
{
    public class HealthStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public int healthLevel;

        public float maxHealth, currentHealth;

        public HealthStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            healthLevel = statsSettings.healthStatsSettings.healthLevel;
            maxHealth = statsSettings.healthStatsSettings.healthLevel * statsSettings.healthStatsSettings.healthLevelMultiplier;
            currentHealth = maxHealth;
        }
    }

    public HealthStatsState healthStatsState;

    public PlayerHealthStats(PlayerWorker playerWorker) => healthStatsState = new HealthStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

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
        healthStatsState.playerWorker.playerAnimation.PlayTargetAnimation("Revive 1", true);
        OnHealthChanged();
    }

    public void OnHealthChanged() => healthStatsState.playerWorker.playerSphere.sphereState.playerHealthSphere.UpdateHealthSphereFillStatus();

    public void HealthRegeneration()
    {
        if (healthStatsState.currentHealth <= healthStatsState.maxHealth)
        {
            healthStatsState.currentHealth += healthStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.healthRegenerationMultiplier * Time.deltaTime;
            if (healthStatsState.currentHealth > healthStatsState.maxHealth) healthStatsState.currentHealth = healthStatsState.maxHealth;
            OnHealthChanged();
        }
    }
}
