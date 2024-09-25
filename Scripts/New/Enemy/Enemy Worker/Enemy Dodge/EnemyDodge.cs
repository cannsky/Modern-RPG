using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge
{
    public class DodgeState
    {
        public EnemyWorker enemyWorker;

        public EnemyDodgeSettings dodgeSettings;

        public bool isDodgeRecovering;

        public float dodgeChance, baseDodgeChance, dodgeChanceIncrease, checkDodgeInterval;

        public DodgeState(EnemyWorker enemyWorker, EnemyDodgeSettings dodgeSettings)
        {
            this.enemyWorker = enemyWorker;
            this.dodgeSettings = dodgeSettings;
            baseDodgeChance = dodgeSettings.baseDodgeChance;
            dodgeChanceIncrease = dodgeSettings.dodgeChanceIncrease;
            checkDodgeInterval = dodgeSettings.checkDodgeInterval;
            dodgeChance = baseDodgeChance;
        }
    }

    public DodgeState dodgeState;

    public EnemyDodge(EnemyWorker enemyWorker) => dodgeState = new DodgeState(enemyWorker, enemyWorker.enemyAI.enemySettings.dodgeSettings);

    public void TryDodge()
    {
        if (!CheckDodgeRecovery() || dodgeState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDodging || dodgeState.dodgeChance < Random.Range(0, 100)) return;
        dodgeState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isDodging = true;
        dodgeState.enemyWorker.enemyAnimation.PlayTargetAnimation("Rollback", true);
    }

    public bool CheckDodgeRecovery()
    {
        if (!dodgeState.isDodgeRecovering)
        {
            dodgeState.enemyWorker.enemyAI.StartCoroutine(StartDodgeRecovery());
            return true;
        }
        else return false;
    }

    public IEnumerator StartDodgeRecovery()
    {
        dodgeState.isDodgeRecovering = true;
        yield return new WaitForSeconds(dodgeState.checkDodgeInterval);
        dodgeState.isDodgeRecovering = false;
    }
}
