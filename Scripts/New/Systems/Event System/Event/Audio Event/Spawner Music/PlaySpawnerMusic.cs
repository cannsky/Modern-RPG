using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Audio Event/Spawner Music Event/Play Spawner Music", order = 1)]
public class PlaySpawnerMusic : AudioEvent
{
    public AudioClip battleMusic;
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!PlayMusic(base.gameObjectSelf)) return false;
        return true;
    }

    public bool PlayMusic(GameObject gameObject)
    {
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.spawnerAudioSource.clip = battleMusic;
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.spawnerAudioSource.Play();
        return true;
    }
}
