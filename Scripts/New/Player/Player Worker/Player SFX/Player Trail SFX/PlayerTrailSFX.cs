using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailSFX
{
    public class TrailSFXState
    {
        public PlayerWorker playerWorker;

        public PlayerSFXSettings sfxSettings;

        public AudioSource trailAudioSource;
        public List<AudioClip> trailAudioClips;

        public TrailSFXState(PlayerWorker playerWorker, PlayerSFXSettings sfxSettings)
        {
            this.playerWorker = playerWorker;
            this.sfxSettings = sfxSettings;
            trailAudioSource = sfxSettings.trailSFXSettings.trailAudioSource;
            trailAudioClips = sfxSettings.trailSFXSettings.trailAudioClips;
        }
    }

    public TrailSFXState trailSFXState;

    public PlayerTrailSFX(PlayerWorker playerWorker) => trailSFXState = new TrailSFXState(playerWorker, playerWorker.player.playerSettings.sfxSettings);

    public void PlayTrailAudio(int sfxValue)
    {
        trailSFXState.trailAudioSource.clip = trailSFXState.trailAudioClips[sfxValue - 1];
        trailSFXState.trailAudioSource.Play();
    }
}
