using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart
{
    public class StartState
    {
        public PlayerWorker playerWorker;

        public StartState(PlayerWorker playerWorker) => this.playerWorker = playerWorker;
    }

    public StartState startState;

    public PlayerStart(PlayerWorker playerWorker) => startState = new StartState(playerWorker);

    public void Start()
    {
        startState.playerWorker.playerCombatTechnique.Start();
        startState.playerWorker.playerControl.Start();
        startState.playerWorker.playerInventory.Start();
        startState.playerWorker.playerMovement.Start();
        startState.playerWorker.playerPhysics.Start();
        startState.playerWorker.playerSphere.Start();
        startState.playerWorker.playerStats.Start();
        startState.playerWorker.playerUI.Start();
        startState.playerWorker.playerWeapon.Start();
    }
}
