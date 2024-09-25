using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevelEndTrigger : MonoBehaviour
{
    public GameEvent gameEvent;

    int objectCount = 0;

    public void EndLevel() => EventSystem.HandleGameEvent(gameEvent, gameObject);

    public void OnSpawnerEnemyDead()
    {
        if (++objectCount == gameObject.transform.childCount) EndLevel();
        Debug.Log(objectCount + " " + gameObject.transform.childCount);
    }

}