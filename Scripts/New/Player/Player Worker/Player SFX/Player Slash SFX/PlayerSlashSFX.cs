using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlashSFX
{
    public class SlashSFXState
    {
        public PlayerWorker playerWorker;

        public PlayerSFXSettings sfxSettings;

        public AudioSource slashAudioSource;
        public List<AudioClip> slashAudioClips;

        public SlashSFXState(PlayerWorker playerWorker, PlayerSFXSettings sfxSettings)
        {
            this.playerWorker = playerWorker;
            this.sfxSettings = sfxSettings;
            slashAudioSource = sfxSettings.slashSFXSettings.slashAudioSource;
            slashAudioClips = sfxSettings.slashSFXSettings.slashAudioClips;
        }
    }

    public SlashSFXState slashSFXState;

    public PlayerSlashSFX(PlayerWorker playerWorker) => slashSFXState = new SlashSFXState(playerWorker, playerWorker.player.playerSettings.sfxSettings);

    public void PlaySlashAudio(int sfxValue)
    {
        slashSFXState.slashAudioSource.clip = slashSFXState.slashAudioClips[sfxValue - 1];
        slashSFXState.slashAudioSource.Play();
    }
}
