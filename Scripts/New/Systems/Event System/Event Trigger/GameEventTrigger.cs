using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTrigger : MonoBehaviour
{
    public class GameEvenTriggerState
    {
        public bool isCooldownEnded = true;
    }

    public GameEvenTriggerState gameEventTriggerState;

    public GameEvent gameEvent;

    public void Start() => gameEventTriggerState = new GameEvenTriggerState();

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player") return;
        if (gameEventTriggerState.isCooldownEnded)
        {
            EventSystem.HandleGameEvent(gameEvent, gameObject, other.gameObject);
            gameEventTriggerState.isCooldownEnded = false;
            Invoke("EndCooldown", 1f);
        }

    }

    public void EndCooldown() => gameEventTriggerState.isCooldownEnded = true;

    public void SpawnerTriggeredHandleGameEvent() => EventSystem.HandleGameEvent(gameEvent, gameObject);
}