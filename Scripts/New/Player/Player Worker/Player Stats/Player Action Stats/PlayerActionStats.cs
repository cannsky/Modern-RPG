using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionStats
{
    public class ActionStatsState
    {
        public PlayerWorker playerWorker;

        public PlayerStatsSettings statsSettings;

        public bool isAttacking, isDead, isExhausted, isMoving, isReviving, isRolling, isSprinting, isCollectingHolyPower;

        public ActionStatsState(PlayerWorker playerWorker, PlayerStatsSettings statsSettings)
        {
            this.playerWorker = playerWorker;
            this.statsSettings = statsSettings;
        }
    }

    public ActionStatsState actionStatsState;

    public PlayerActionStats(PlayerWorker playerWorker) => actionStatsState = new ActionStatsState(playerWorker, playerWorker.player.playerSettings.statsSettings);

    public bool CheckGiveDamageAvailable() => !actionStatsState.isRolling;

    public bool CheckUpdateAvaiable() => !actionStatsState.isDead;

    public bool CheckMovementAvailable() =>  !(actionStatsState.isAttacking || actionStatsState.isReviving);

    public bool CheckAttackMovementAvailable() => actionStatsState.isAttacking || actionStatsState.isReviving;

    public bool CheckEnergyUsageAvailable() => !actionStatsState.isExhausted;

    public bool CheckFootPlacementAvailable() => !(actionStatsState.isMoving || actionStatsState.isRolling || actionStatsState.isSprinting);
}
