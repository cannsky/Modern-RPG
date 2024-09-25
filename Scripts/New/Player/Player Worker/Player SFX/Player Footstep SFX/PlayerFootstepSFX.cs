using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSFX : MonoBehaviour
{
    public class FootstepSFXState
    {
        public PlayerWorker playerWorker;

        public PlayerSFXSettings sfxSettings;

        public AudioSource footstepAudioSource;
        public List<AudioClip> footstepAudioClips;

        public FootstepSFXState(PlayerWorker playerWorker, PlayerSFXSettings sfxSettings)
        {
            this.playerWorker = playerWorker;
            this.sfxSettings = sfxSettings;
            footstepAudioSource = sfxSettings.footstepSFXSettings.footstepAudioSource;
            footstepAudioClips = sfxSettings.footstepSFXSettings.footstepAudioClips;
        }
    }

    public FootstepSFXState footstepSFXState;

    public PlayerFootstepSFX(PlayerWorker playerWorker) => footstepSFXState = new FootstepSFXState(playerWorker, playerWorker.player.playerSettings.sfxSettings);

    public void Update()
    {
        
    }

    public void PlayFootstepAudio(int sfxValue)
    {
        footstepSFXState.footstepAudioSource.clip = footstepSFXState.footstepAudioClips[sfxValue - 1];
        footstepSFXState.footstepAudioSource.Play();
    }
}
