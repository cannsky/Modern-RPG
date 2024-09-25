using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSpawnerLevelEnd : MonoBehaviour
{
    public GameEvent gameEvent;

    public void EndLevel() => EventSystem.HandleGameEvent(gameEvent, gameObject);
}
