using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack
{
    public class AttackState
    {
        public PlayerWorker playerWorker;

        public PlayerAttackSettings attackSettings;

        public PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack currentCombatTechniqueAttack;

        public AttackState(PlayerWorker playerWorker, PlayerAttackSettings attackSettings)
        {
            this.playerWorker = playerWorker;
            this.attackSettings = attackSettings;
        }
    }

    public AttackState attackState;

    public PlayerAttack(PlayerWorker playerWorker) => attackState = new AttackState(playerWorker, playerWorker.player.playerSettings.attackSettings);

    public void Attack()
    {
        if (attackState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isReviving &&
            attackState.playerWorker.playerStats.statsState.playerEnergyStats.energyStatsState.currentEnergy <
            attackState.playerWorker.playerStats.statsState.playerMultiplierStats.multiplierStatsState.attackEnergyDecreaseMultiplier) return;
        if ((attackState.currentCombatTechniqueAttack = attackState.playerWorker.playerCombatTechnique.combatTechniqueState.playerCombatTechniqueQueue.GetCombatTechniqueAttack()) == null) return;
        attackState.playerWorker.playerStance.ChangeToAggressiveStanceFast();
        attackState.playerWorker.playerStats.statsState.playerActionStats.actionStatsState.isAttacking = true;
        attackState.playerWorker.playerStats.statsState.playerEnergyStats.DecreaseEnergy();
        attackState.playerWorker.playerAnimation.PlayTargetAnimation(attackState.currentCombatTechniqueAttack.animationName, true);
    }
}
