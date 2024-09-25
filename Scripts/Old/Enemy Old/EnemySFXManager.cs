using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFXManager : MonoBehaviour
{
    [System.Serializable]
    public class EnemyAudioConfig
    {
        public List<AudioClip> attackSFX;
    }

    public EnemyAudioConfig enemyAudioConfig;
    public AudioSource enemySFXAudioSource;

    public void PlayAudio(int sfxValue)
    {
        enemySFXAudioSource.clip = enemyAudioConfig.attackSFX[sfxValue - 1];
        enemySFXAudioSource.Play();
    }
}
