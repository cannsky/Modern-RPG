using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHolyPowerStats
{
    public class HolyPowerStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public int holyPowerLevel;

        public float maxHolyPower, currentHolyPower, decreaseAmount;

        public HolyPowerStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            holyPowerLevel = statsSettings.holyPowerStatsSettings.holyPowerLevel;
            maxHolyPower = statsSettings.holyPowerStatsSettings.holyPowerLevel * statsSettings.holyPowerStatsSettings.holyPowerLevelMultiplier;
            currentHolyPower = maxHolyPower;
        }
    }

    public HolyPowerStatsState holyPowerStatsState;

    public PlayerHolyPowerStats(PlayerWorker playerWorker) => holyPowerStatsState = new HolyPowerStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

    public void Update()
    {
        if (holyPowerStatsState.currentHolyPower / holyPowerStatsState.currentHolyPower <= 0.01)
            holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isCollectingHolyPower = true;
        else if (holyPowerStatsState.currentHolyPower / holyPowerStatsState.maxHolyPower >= 0.2 &&
            !holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.CheckEnergyUsageAvailable())
            holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isCollectingHolyPower = false;
        HolyPowerRegeneration();
    }

    public void DecreaseHolyPower()
    {
        if (holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isSprinting)
            holyPowerStatsState.decreaseAmount = holyPowerStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.sprintEnergyDecreaseMultiplier * Time.deltaTime;
        if (holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking)
            holyPowerStatsState.decreaseAmount = holyPowerStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.attackEnergyDecreaseMultiplier;
        if (holyPowerStatsState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isRolling)
            holyPowerStatsState.decreaseAmount = holyPowerStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.rollEnergyDecreaseMultiplier;
        holyPowerStatsState.currentHolyPower -= holyPowerStatsState.decreaseAmount;
        OnHolyPowerChanged();
    }

    public void Revive()
    {
        holyPowerStatsState.currentHolyPower = holyPowerStatsState.maxHolyPower;
        OnHolyPowerChanged();
    }

    public void OnHolyPowerChanged() => holyPowerStatsState.playerWorker.playerSphere.sphereState.playerHolyPowerSphere.UpdateHolyPowerSphereFillStatus();

    public void HolyPowerRegeneration()
    {
        if (holyPowerStatsState.currentHolyPower <= holyPowerStatsState.maxHolyPower)
        {
            holyPowerStatsState.currentHolyPower += holyPowerStatsState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.energyRegenerationMultiplier * Time.deltaTime;
            if (holyPowerStatsState.currentHolyPower > holyPowerStatsState.maxHolyPower) holyPowerStatsState.currentHolyPower = holyPowerStatsState.maxHolyPower;
            OnHolyPowerChanged();
        }
    }
}
