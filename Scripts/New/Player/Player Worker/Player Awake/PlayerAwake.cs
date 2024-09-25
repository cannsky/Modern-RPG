using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwake
{
    public class AwakeState
    {
        public PlayerWorker playerWorker;

        public AwakeState(PlayerWorker playerWorker) => this.playerWorker = playerWorker;
    }

    public AwakeState awakeState;

    public PlayerAwake(PlayerWorker playerWorker) => awakeState = new AwakeState(playerWorker);

    public void Awake()
    {
        awakeState.playerWorker.playerCamera.Awake();
    }
}
