using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage
{
    public class DamageState
    {
        public EnemyWorker enemyWorker;

        public EnemyDamageSettings damageSettings;

        public DamageState(EnemyWorker enemyWorker, EnemyDamageSettings damageSettings)
        {
            this.enemyWorker = enemyWorker;
            this.damageSettings = damageSettings;
        }
    }

    public DamageState damageState;

    public EnemyDamage(EnemyWorker enemyWorker) => damageState = new DamageState(enemyWorker, enemyWorker.enemyAI.enemySettings.damageSettings);

    public void HandleDamage(float damage)
    {
        if (!damageState.enemyWorker.enemyStats.statsState.enemyActionStats.CheckGiveDamageAvailable()) return;
        damageState.enemyWorker.enemyStats.statsState.enemyHealthStats.TakeDamage(damage);
        damageState.enemyWorker.enemyDodge.dodgeState.dodgeChance += damageState.enemyWorker.enemyDodge.dodgeState.dodgeChanceIncrease;
        if (damageState.enemyWorker.enemyStats.statsState.enemyHealthStats.healthStatsState.currentHealth <= 0f) HandleDeath();
        else if(!damageState.enemyWorker.enemyParry.CheckParryAvailable()) HandleHit();
    }

    public void HandleDeath() => damageState.enemyWorker.enemyDeath.OnDeath();

    public void HandleHit()
    {
        damageState.enemyWorker.enemyAnimation.PlayTargetAnimation("Damage Front 1", true);
        damageState.enemyWorker.enemyAnimation.PlayTargetAnimation("Damage Front Walk", true);
        if (damageState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isAttacking &&
            !damageState.enemyWorker.enemyAnimation.animationState.animator.GetBool("isDamaged"))
            damageState.enemyWorker.enemyAnimation.animationState.animator.SetBool("isDamaged", true);
        damageState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isReviving = true;
    }
}
