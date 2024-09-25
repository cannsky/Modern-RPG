using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadedCallback : MonoBehaviour
{
    private bool isFirstUpdate = false;

    
    private void Update()
    {
        if (!isFirstUpdate)
        {
            isFirstUpdate = true;
            GameSceneLoader.LoadedCallback();
        }
    }
}