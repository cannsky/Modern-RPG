using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Audio Event/Spawner Music Event/Stop Spawner Music", order = 2)]
public class StopSpawnerMusic : AudioEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!PlayMusic(base.gameObjectSelf)) return false;
        return true;
    }

    public bool PlayMusic(GameObject gameObject)
    {
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.spawnerAudioSource.Stop();
        return true;
    }
}
