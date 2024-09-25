using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Spawner Event/Open Spawner Gate", order = 3)]
public class OpenSpawnerGate : WorldEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!OpenGate(base.gameObjectSelf.transform.parent.parent.GetChild(2).GetChild(6).gameObject)) return false;
        return true;
    }

    public bool OpenGate(GameObject gameObject)
    {
        gameObject.GetComponent<GameEventTrigger>().SpawnerTriggeredHandleGameEvent();
        return true;
    }
}
