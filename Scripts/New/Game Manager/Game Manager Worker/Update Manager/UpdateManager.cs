using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager
{
    public GameManagerWorker gameManagerWorker;

    public UpdateManager(GameManagerWorker gameManagerWorker) => this.gameManagerWorker = gameManagerWorker;

    public void Update()
    {
        gameManagerWorker.musicManager.Update();
    }
}
