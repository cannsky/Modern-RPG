using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : ScriptableObject
{
    [System.NonSerialized] public GameObject gameObjectSelf;
    [System.NonSerialized] public GameObject gameObjectTarget;
    [System.NonSerialized] public List<GameObject> effectedGameObjectList = new List<GameObject>();

    public List<int> effectedGameObjectIDList;
    public List<GameEvent> thrownEventsBefore;
    public List<GameEvent> thrownEventsAfter;

    public bool isEffectTargetList = true;
    public bool isEffectTarget = false;
    public bool isEffectItSelf = false;
    public bool isEffectPlayer = false;

    public bool UpdateEvent(GameObject gameObjectSelf)
    {
        this.gameObjectSelf = gameObjectSelf;

        foreach (int id in this.effectedGameObjectIDList) effectedGameObjectList.Add(EventSystem.eventGameObjects[id]);

        foreach (GameEvent gameEventBefore in thrownEventsBefore)
            if (!gameEventBefore.UpdateEvent(gameObjectSelf)) return false;

        if (!this.HandleEvent()) return false;

        foreach (GameEvent gameEventAfter in thrownEventsAfter)
            if (!gameEventAfter.UpdateEvent(gameObjectSelf)) return false;

        return true;
    }

    public bool UpdateEvent(GameObject gameObjectSelf, GameObject gameObjectTarget)
    {
        this.gameObjectSelf = gameObjectSelf;
        this.gameObjectTarget = gameObjectTarget;

        foreach (int id in this.effectedGameObjectIDList) effectedGameObjectList.Add(EventSystem.eventGameObjects[id]);

        foreach (GameEvent gameEventBefore in thrownEventsBefore)
            if (!gameEventBefore.UpdateEvent(gameObjectSelf, gameObjectTarget)) return false;

        if (!this.HandleEvent()) return false;

        foreach (GameEvent gameEventAfter in thrownEventsAfter)
            if (!gameEventAfter.UpdateEvent(gameObjectSelf, gameObjectTarget)) return false;

        return true;
    }

    public virtual bool HandleEvent() => true;
}
