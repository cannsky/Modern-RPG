using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem
{
    public static Dictionary<int, GameObject> eventGameObjects = new Dictionary<int, GameObject>();

    public static void HandleGameEvent(GameEvent gameEvent, GameObject gameObjectSelf)
    {
        if (gameEvent == null || gameObjectSelf == null) return;

        if (!gameEvent.UpdateEvent(gameObjectSelf)) return;

    }

    public static void HandleGameEvent(GameEvent gameEvent, GameObject gameObjectSelf, GameObject gameObjectTarget)
    {
        if (gameEvent == null || gameObjectSelf == null || gameObjectTarget == null) return;

        if (!gameEvent.UpdateEvent(gameObjectSelf, gameObjectTarget)) return;
    }
}
