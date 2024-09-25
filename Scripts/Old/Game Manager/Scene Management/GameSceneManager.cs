using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager instance;

    public static GameSceneManager Instance { get => instance; }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }

    public void ReloadCurrentScene() => LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void LoadNextScene() => LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    public void LoadScene(int buildIndex) => GameSceneLoader.Load((GameSceneLoader.Scene)buildIndex);

    public void LoadScene(string name)
    {
        switch (name)
        {
            case "Dungeon":
                GameSceneLoader.Load(GameSceneLoader.Scene.Dungeon);
                break;
            case "MainMenu":
                GameSceneLoader.Load(GameSceneLoader.Scene.MainMenu);
                break;
            default:
                Debug.LogWarning("Warning : Invalid scene name");
                break;
        }
    }
}