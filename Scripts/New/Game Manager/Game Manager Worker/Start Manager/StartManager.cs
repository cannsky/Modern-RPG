using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager
{
    public GameManagerWorker gameManagerWorker;

    public StartManager(GameManagerWorker gameManagerWorker) => this.gameManagerWorker = gameManagerWorker;

    public void Start()
    {
        gameManagerWorker.musicManager.Start();
    }
}
