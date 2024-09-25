using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderCallback : MonoBehaviour
{
    private bool isFirstUpdate = false;

    private void Update()
    {
        if (!isFirstUpdate)
        {
            isFirstUpdate = true;
            GameSceneLoader.LoaderCallback();
        }
    }
}
