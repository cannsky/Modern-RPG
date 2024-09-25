using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage
{
    public class DamageState
    {
        public PlayerWorker playerWorker;

        public PlayerDamageSettings damageSettings;

        public DamageState(PlayerWorker playerWorker, PlayerDamageSettings damageSettings)
        {
            this.playerWorker = playerWorker;
            this.damageSettings = damageSettings;
        }
    }

    public DamageState damageState;

    public PlayerDamage(PlayerWorker playerWorker) => damageState = new DamageState(playerWorker, playerWorker.player.playerSettings.damageSettings);

    public void HandleDamage(float damage)
    {
        if (!damageState.playerWorker.playerStats.statsState.playerActionStats.CheckGiveDamageAvailable()) return;
        damageState.playerWorker.playerStats.statsState.playerHealthStats.TakeDamage(damage);
        if (damageState.playerWorker.playerStats.statsState.playerHealthStats.healthStatsState.currentHealth <= 0f) HandleDeath();
        else HandleHit();
    }

    public void HandleDeath()
    {
        damageState.playerWorker.playerAnimation.PlayTargetAnimation("Death 1", true);
        damageState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isDead = true;
    }

    public void HandleHit()
    {
        damageState.playerWorker.playerStance.ChangeToAggressiveStance();
        damageState.playerWorker.playerAnimation.PlayTargetAnimation("Damage Front 1", true);
        if (damageState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking &&
            !damageState.playerWorker.playerAnimation.animationState.animators[0].GetBool("isDamaged"))
            foreach(Animator animator in damageState.playerWorker.playerAnimation.animationState.animators) animator.SetBool("isDamaged", true);
        damageState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isReviving = true;
    }
}
