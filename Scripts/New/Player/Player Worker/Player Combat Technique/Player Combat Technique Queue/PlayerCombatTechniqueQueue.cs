using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatTechniqueQueue
{
    public class CombatTechniqueQueueState
    {
        public PlayerWorker playerWorker;

        public PlayerCombatTechnique.CombatTechniqueState combatTechniqueState;

        public PlayerCombatTechniqueSettings combatTechniqueSettings;

        public Queue<PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack> combatTechniqueAttackQueue;

        public bool isCombatTechniqueReady = true;

        public float combatTechniqueAttackComboResetTime, combatTechniqueAttackComboTime;

        public int combatTechniqueAttackQueueIndex;
        public CombatTechniqueQueueState(PlayerWorker playerWorker, PlayerCombatTechniqueSettings combatTechniqueSettings)
        {
            this.playerWorker = playerWorker;
            this.combatTechniqueSettings = combatTechniqueSettings;
            combatTechniqueAttackComboResetTime = combatTechniqueSettings.combatTechniqueAttackComboResetTime;
        }

        public void InitializeCombatTechniqueQueueState(PlayerCombatTechnique playerCombatTechnique)
        {
            combatTechniqueState = playerCombatTechnique.combatTechniqueState;
            combatTechniqueAttackQueue = new Queue<PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack>(combatTechniqueState.currentCombatTechnique.combatTechniqueAttacks);
        }
    }

    public CombatTechniqueQueueState combatTechniqueQueueState;

    public PlayerCombatTechniqueQueue(PlayerWorker playerWorker) => combatTechniqueQueueState = new CombatTechniqueQueueState(playerWorker, playerWorker.player.playerSettings.combatTechniqueSettings);

    public void ResetQueue() => combatTechniqueQueueState.combatTechniqueAttackQueue = new Queue<PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack>(combatTechniqueQueueState.combatTechniqueState.currentCombatTechnique.combatTechniqueAttacks);

    public PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack Dequeue() => combatTechniqueQueueState.combatTechniqueAttackQueue.Dequeue();

    public PlayerCombatTechniqueSettings.CombatTechnique.CombatTechniqueAttack GetCombatTechniqueAttack()
    {
        if (!combatTechniqueQueueState.isCombatTechniqueReady) return null;
        if (combatTechniqueQueueState.combatTechniqueAttackQueue.Count == 0) ResetQueue();
        combatTechniqueQueueState.combatTechniqueAttackComboTime = combatTechniqueQueueState.combatTechniqueAttackComboResetTime;
        combatTechniqueQueueState.isCombatTechniqueReady = false;
        return Dequeue();
    }

    public void Update()
    {
        if ((combatTechniqueQueueState.combatTechniqueAttackComboTime -= combatTechniqueQueueState.combatTechniqueAttackComboResetTime * Time.deltaTime) <= 0f) ResetQueue();
    }
}
