using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameManagerSettings gameManagerSettings;

    public GameManagerWorker gameManagerWorker;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        gameManagerWorker = new GameManagerWorker(this);
    }

    private void Start() => gameManagerWorker.StartCall();

    private void Update() => gameManagerWorker.UpdateCall();
}
