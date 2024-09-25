using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventObject : MonoBehaviour
{
    public int id;

    public bool isEnabled;

    private void Start()
    {
        EventSystem.eventGameObjects.Add(id, this.gameObject);
        gameObject.SetActive(isEnabled);
    }
}