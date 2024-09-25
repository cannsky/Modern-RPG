using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatTechnique
{
    public class CombatTechniqueState
    {
        public PlayerWorker playerWorker;

        public PlayerCombatTechniqueSettings combatTechniqueSettings;

        public PlayerCombatTechniqueSettings.CombatTechnique currentCombatTechnique;

        public PlayerCombatTechniqueQueue playerCombatTechniqueQueue;

        public CombatTechniqueState(PlayerWorker playerWorker, PlayerCombatTechniqueSettings combatTechniqueSettings)
        {
            this.playerWorker = playerWorker;
            this.combatTechniqueSettings = combatTechniqueSettings;
            currentCombatTechnique = combatTechniqueSettings.combatTechniques[(int)combatTechniqueSettings.defaultCombatTechnique];
            playerCombatTechniqueQueue = new PlayerCombatTechniqueQueue(playerWorker);
        }

        public void InitializeCombatTechniqueState(PlayerCombatTechnique playerCombatTechnique)
        {
            playerCombatTechniqueQueue.combatTechniqueQueueState.InitializeCombatTechniqueQueueState(playerCombatTechnique);
        }
    }

    public CombatTechniqueState combatTechniqueState;

    public PlayerCombatTechnique(PlayerWorker playerWorker) => combatTechniqueState = new CombatTechniqueState(playerWorker, playerWorker.player.playerSettings.combatTechniqueSettings);

    public void Start() => combatTechniqueState.InitializeCombatTechniqueState(this);

    public void Update() => combatTechniqueState.playerCombatTechniqueQueue.Update();

}
