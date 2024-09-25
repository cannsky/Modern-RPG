using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Audio Event/Progress Music Event/Play Progress Music", order = 1)]
public class PlayProgressMusic : AudioEvent
{
    public AudioClip progressMusic;
    public override bool HandleEvent()
    {
        if (base.isEffectTargetList)
            foreach (GameObject gameObject in base.effectedGameObjectList) if (!PlayMusic(gameObject)) return false;
        if (base.isEffectTarget)
            if (!PlayMusic(base.gameObjectTarget)) return false;
        if (base.isEffectItSelf)
            if (!PlayMusic(base.gameObjectSelf)) return false;
        return true;
    }

    public bool PlayMusic(GameObject gameObject)
    {
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.environmentAudioSource.clip = progressMusic;
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.environmentAudioSource.Play();
        return true;
    }
}
