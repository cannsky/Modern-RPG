using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerationController : MonoBehaviour
{
    private static EnumerationController instance;

    public static EnumerationController Instance { get => instance; }

    public void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }

    public void HandleEnumeration(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
