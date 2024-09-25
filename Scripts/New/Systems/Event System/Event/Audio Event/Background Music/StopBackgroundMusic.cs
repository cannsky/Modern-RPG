using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/Audio Event/Background Music Event/Stop Background Music", order = 2)]
public class StopBackgroundMusic : AudioEvent
{
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
        GameManager.Instance.gameManagerWorker.musicManager.musicManagerState.backgroundMusicAudioSource.Stop();
        return true;
    }
}
