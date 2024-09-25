using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLateUpdate
{
    public class LateUpdateState
    {
        public PlayerWorker playerWorker;

        public LateUpdateState(PlayerWorker playerWorker) => this.playerWorker = playerWorker;
    }

    public LateUpdateState lateUpdateState;

    public PlayerLateUpdate(PlayerWorker playerWorker) => lateUpdateState = new LateUpdateState(playerWorker);

    public void LateUpdate()
    {
        if (lateUpdateState.playerWorker.playerStats.statsState.playerActionStats.CheckUpdateAvaiable()) WorkerLateUpdate();
    }

    public void WorkerLateUpdate()
    {
        lateUpdateState.playerWorker.playerControl.LateUpdate();
    }
}
