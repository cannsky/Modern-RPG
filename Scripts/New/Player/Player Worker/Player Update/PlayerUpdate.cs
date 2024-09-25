using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpdate
{
    public class UpdateState
    {
        public PlayerWorker playerWorker;

        public UpdateState(PlayerWorker playerWorker) => this.playerWorker = playerWorker;
    }

    public UpdateState updateState;

    public PlayerUpdate(PlayerWorker playerWorker) => updateState = new UpdateState(playerWorker);

    public void Update()
    {
        if (updateState.playerWorker.playerStats.statsState.playerActionStats.CheckUpdateAvaiable()) WorkerUpdate();
    }

    public void WorkerUpdate()
    {
        updateState.playerWorker.playerControl.Update();
        updateState.playerWorker.playerCombatTechnique.Update();
        updateState.playerWorker.playerMovement.Update();
        updateState.playerWorker.playerPhysics.Update();
        updateState.playerWorker.playerStance.Update();
        updateState.playerWorker.playerStats.Update();
    }
}
