using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElementStats
{
    public class ElementStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public int element;

        public ElementStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            element = (int) statsSettings.elementStatsSettings.element;
        }
    }

    public ElementStatsState elementStatsState;

    public PlayerElementStats(PlayerWorker playerWorker) => elementStatsState = new ElementStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);
}
