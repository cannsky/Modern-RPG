using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaStats
{
    public class ManaStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public int manaLevel;

        public float maxMana, currentMana;

        public ManaStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
            manaLevel = statsSettings.manaStatsSettings.manaLevel;
            maxMana = statsSettings.manaStatsSettings.manaLevel * statsSettings.manaStatsSettings.manaLevelMultiplier;
            currentMana = maxMana;
        }
    }

    public ManaStatsState manaStatsState;

    public PlayerManaStats(PlayerWorker playerWorker) => manaStatsState = new ManaStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

    public void Start() => OnManaChanged();

    public void OnManaChanged() => manaStatsState.playerWorker.playerSphere.sphereState.playerManaSphere.UpdateManaSphereFillStatus();
}
