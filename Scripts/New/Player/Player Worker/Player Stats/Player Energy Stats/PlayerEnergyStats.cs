using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergyStats
{
    public class EnergyStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public int energyLevel;

        public float maxEnergy, currentEnergy, decreaseAmount;

        public EnergyStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            energyLevel = statsSettings.energyStatsSettings.energyLevel;
            maxEnergy = statsSettings.energyStatsSettings.energyLevel * statsSettings.energyStatsSettings.energyLevelMultiplier;
            currentEnergy = maxEnergy;
        }
    }

    public EnergyStatsState energyStatsState;

    public PlayerEnergyStats(PlayerWorker playerWorker) => energyStatsState = new EnergyStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

    public void Start() => OnEnergyChanged();

    public void Update()
    {
        if (energyStatsState.currentEnergy / energyStatsState.maxEnergy <= 0.01) 
            energyStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isExhausted = true;
        else if (energyStatsState.currentEnergy / energyStatsState.maxEnergy >= 0.05 && 
            !energyStatsState.playerWorker.playerStats.statsState.playerActionStats.CheckEnergyUsageAvailable()) 
            energyStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isExhausted = false;
        HealthRegeneration();
    }

    public void DecreaseEnergy()
    {
        if (energyStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting)
            energyStatsState.decreaseAmount = energyStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.sprintEnergyDecreaseMultiplier * Time.deltaTime;
        if (energyStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking)
            energyStatsState.decreaseAmount = energyStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.attackEnergyDecreaseMultiplier;
        if (energyStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isRolling)
            energyStatsState.decreaseAmount = energyStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.rollEnergyDecreaseMultiplier;
        energyStatsState.currentEnergy -= energyStatsState.decreaseAmount;
        OnEnergyChanged();
    }

    public void Revive()
    {
        energyStatsState.currentEnergy = energyStatsState.maxEnergy;
        OnEnergyChanged();
    }

    public void OnEnergyChanged() => energyStatsState.playerWorker.playerSphere.sphereState.playerEnergySphere.UpdateEnergySphereFillStatus();

    public void HealthRegeneration()
    {
        if (energyStatsState.currentEnergy <= energyStatsState.maxEnergy)
        {
            energyStatsState.currentEnergy += energyStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.energyRegenerationMultiplier * Time.deltaTime;
            if (energyStatsState.currentEnergy > energyStatsState.maxEnergy) energyStatsState.currentEnergy = energyStatsState.maxEnergy;
            OnEnergyChanged();
        }
    }
}
