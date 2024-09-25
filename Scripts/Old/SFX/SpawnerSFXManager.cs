using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSFXManager : MonoBehaviour
{
    static SpawnerSFXManager instance;
    public static SpawnerSFXManager Instance { get => instance; }

    public AudioSource spawnerAudio;
    public AudioSource spawnerBackgroundAudio;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(this);
    }
    public static void PlaySpawnerAudio(AudioClip audioClip)
    {
        Instance.spawnerAudio.clip = audioClip;
        Instance.spawnerAudio.Play();
    }

    public static void PlaySpawnerBackgroundMusic(AudioClip audioClip)
    {
        Instance.spawnerBackgroundAudio.clip = audioClip;
        Instance.spawnerBackgroundAudio.Play();
    }

    public static void StopSpawnerBackgroundMusic() => Instance.spawnerBackgroundAudio.Stop();
}
