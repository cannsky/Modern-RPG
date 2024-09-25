using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMultiplierStats
{
    public class MultiplierStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public float healthRegenerationMultiplier, energyRegenerationMultiplier;

        public float attackEnergyDecreaseMultiplier, sprintEnergyDecreaseMultiplier, rollEnergyDecreaseMultiplier;

        public MultiplierStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            healthRegenerationMultiplier = statsSettings.multiplierStatsSettings.healthRegenerationMultiplier;
            energyRegenerationMultiplier = statsSettings.multiplierStatsSettings.energyRegenerationMultiplier;
            attackEnergyDecreaseMultiplier = statsSettings.multiplierStatsSettings.attackEnergyDecreaseMultiplier;
            sprintEnergyDecreaseMultiplier = statsSettings.multiplierStatsSettings.sprintEnergyDecreaseMultiplier;
            rollEnergyDecreaseMultiplier = statsSettings.multiplierStatsSettings.rollEnergyDecreaseMultiplier;
        }
    }

    public MultiplierStatsState multiplierStatsState;

    public PlayerMultiplierStats(PlayerWorker playerWorker) => multiplierStatsState = new MultiplierStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);
}
