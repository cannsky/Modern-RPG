using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public class StatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public PlayerActionStats playerActionStats;
        public PlayerElementStats playerElementStats;
        public PlayerEnergyStats playerEnergyStats;
        public PlayerHealthStats playerHealthStats;
        public PlayerHolyPowerStats playerHolyPowerStats;
        public PlayerManaStats playerManaStats;
        public PlayerMultiplierStats playerMultiplierStats;

        public StatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            playerActionStats = new PlayerActionStats(playerWorker);
            playerElementStats = new PlayerElementStats(playerWorker);
            playerEnergyStats = new PlayerEnergyStats(playerWorker);
            playerHealthStats = new PlayerHealthStats(playerWorker);
            playerHolyPowerStats = new PlayerHolyPowerStats(playerWorker);
            playerManaStats = new PlayerManaStats(playerWorker);
            playerMultiplierStats = new PlayerMultiplierStats(playerWorker);
        }
    }

    public StatsState statsState;

    public PlayerStats(PlayerWorker playerWorker) => statsState = new StatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

    public void Start()
    {
        statsState.playerHealthStats.Start();
        statsState.playerManaStats.Start();
    }

    public void Update()
    {
        statsState.playerEnergyStats.Update();
        statsState.playerHealthStats.Update();
    }
}
