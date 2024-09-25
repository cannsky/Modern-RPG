using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFixedUpdate
{
    public class FixedUpdateState
    {
        public PlayerWorker playerWorker;

        public FixedUpdateState(PlayerWorker playerWorker) => this.playerWorker = playerWorker;
    }

    public FixedUpdateState fixedUpdateState;

    public PlayerFixedUpdate(PlayerWorker playerWorker) => fixedUpdateState = new FixedUpdateState(playerWorker);

    public void FixedUpdate()
    {
        if (fixedUpdateState.playerWorker.playerStats.statsState.playerActionStats.CheckUpdateAvaiable()) WorkerFixedUpdate(); 
    }

    public void WorkerFixedUpdate()
    {
        fixedUpdateState.playerWorker.playerAnimation.FixedUpdate();
        fixedUpdateState.playerWorker.playerCamera.FixedUpdate();
        fixedUpdateState.playerWorker.playerMovement.FixedUpdate();
        fixedUpdateState.playerWorker.playerPhysics.FixedUpdate();
        fixedUpdateState.playerWorker.playerRotation.FixedUpdate();
    }
}
