using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActionStats
{
    public class ActionStatsState
    {
        public EnemyWorker enemyWorker;

        public EnemyStatsSettings statsSettings;

        public bool isAttackRecovering, isDead, isDodging, isInteracting, isReviving, isRotateWithRootMotion, isCanRotate;

        //Old

        public bool isAttacking, isSpawning, isDisabled;
        public bool isHit;

        public ActionStatsState(EnemyWorker enemyWorker, EnemyStatsSettings statsSettings)
        {
            this.enemyWorker = enemyWorker;
            this.statsSettings = statsSettings;
        }
    }

    public ActionStatsState actionStatsState;

    public EnemyActionStats(EnemyWorker enemyWorker) => actionStatsState = new ActionStatsState(enemyWorker, enemyWorker.enemyAI.enemySettings.statsSettings);

    public bool CheckGiveDamageAvailable() => !actionStatsState.isDodging;

    public bool CheckUpdateAvaiable() => !actionStatsState.isDead;

    public bool CheckMovementAvailable() => !(actionStatsState.isAttacking || actionStatsState.isReviving);
}
