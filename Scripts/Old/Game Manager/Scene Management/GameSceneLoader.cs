using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneLoader
{
    private static Action onLoaderCallback, onLoadedCallback;
    private static AsyncOperation loadingAsyncOperation;

    private class LoadingMonobehavior : MonoBehaviour { }

    public enum Scene
    {
        MainMenu=2,
        Dungeon=3,
    }

    public static void Load(Scene scene)
    {
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            var loadingBehaviour =loadingGameObject.AddComponent<LoadingMonobehavior>();
            IEnumerator coroutine = LoadSceneAsync(scene);
            EnumerationController.Instance.HandleEnumeration(coroutine);
            Debug.Log(scene.ToString() + " is loading");
        };

        onLoadedCallback = () =>
        {
            HandleNewScene(scene.ToString());
        };
        SceneManager.LoadScene(1);
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        Debug.Log("ayeasd");
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());

        while (!loadingAsyncOperation.isDone)
        {
            Debug.Log("Async operation is still not done - scene : " + scene.ToString());
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if(loadingAsyncOperation != null)
            return loadingAsyncOperation.progress;
        else return 1f;
    }

    public static void LoaderCallback()
    {
        if(onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }

    public static void LoadedCallback()
    {
        if (onLoadedCallback != null)
        {
            Debug.Log("loaded callback is being executed");
            onLoadedCallback();
            onLoadedCallback = null;
        }
    }

    private static void HandleNewScene(string newScene)
    {
        /*
        Debug.Log("New scene is being handled");
        switch (newScene)
        {
            case "Demo Main Menu":
                //nothing atm
                break;
            case "Dungeon":
                var inputManager = Settings.Instance.GetComponent<InputManager>();
                inputManager.OnStartup();
                inputManager.enabled = true;
                Settings.Instance.GetComponent<MusicManager>().enabled = true;
                Settings.Instance.GetComponent<Clicker>().enabled = true;
                break;
            default:
                break;
        }
        */
    }
}