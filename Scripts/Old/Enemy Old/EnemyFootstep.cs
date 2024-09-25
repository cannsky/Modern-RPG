using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootstep : MonoBehaviour
{
    [System.Serializable]
    public class EnemyAudioConfig
    {
        public List<AudioClip> footstepSFX;
    }

    public EnemyAudioConfig enemyAudioConfig;
    public AudioSource enemySFXAudioSource;

    public void PlayFootstepAudio(int sfxValue)
    {
        if (gameObject.tag == "Animator2")
            return;
        enemySFXAudioSource.clip = enemyAudioConfig.footstepSFX[sfxValue - 1];
        enemySFXAudioSource.Play();
    }
}
