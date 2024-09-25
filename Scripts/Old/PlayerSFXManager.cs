using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerAudioConfig
    {
        public List<AudioClip> attackSlashSFX;
        public List<AudioClip> attackSkillSFX;
        public AudioClip hitAudio;
        public float hitWaitTime = 0.1f;
    }

    public PlayerAudioConfig playerAudioConfig;
    public AudioSource playerSFXAudioSource;
    public AudioSource playerHitSFXAudioSource;

    public void PlaySlashAudio(int sfxValue)
    {
        playerSFXAudioSource.clip = playerAudioConfig.attackSlashSFX[sfxValue - 1];
        playerHitSFXAudioSource.clip = playerAudioConfig.hitAudio;
        playerSFXAudioSource.Play();
        StartCoroutine(PlayLater(playerHitSFXAudioSource, playerAudioConfig.hitWaitTime));
    }

    public void PlaySkillAudio(int sfxValue)
    {
        playerSFXAudioSource.clip = playerAudioConfig.attackSkillSFX[sfxValue - 1];
        playerSFXAudioSource.Play();
    }

    public IEnumerator PlayLater(AudioSource audioSource, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        audioSource.Play();
    }
}
