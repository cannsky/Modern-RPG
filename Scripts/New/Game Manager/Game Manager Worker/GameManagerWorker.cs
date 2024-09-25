using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerWorker
{
    public GameManager gameManager;

    public MusicManager musicManager;
    public StartManager startManager;
    public UpdateManager updateManager;

    public GameManagerWorker(GameManager gameManager)
    {
        this.gameManager = gameManager;
        musicManager = new MusicManager(this);
        startManager = new StartManager(this);
        updateManager = new UpdateManager(this);
    }

    public void StartCall() => startManager.Start();

    public void UpdateCall() => updateManager.Update();
}
