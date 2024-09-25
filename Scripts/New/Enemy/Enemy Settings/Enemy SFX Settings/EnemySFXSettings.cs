using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySFXSettings
{
    [System.Serializable]
    public class SpeechSFXSettings
    {
        [SerializeField] public AudioSource speechAudioSource;
        [SerializeField] public List<AudioClip> customLine;
        [SerializeField] public AudioClip battleCry;
        [SerializeField] public AudioClip laugh;
        [SerializeField] public AudioClip death;
        [Range(0, 10)] [SerializeField] public float resetTime = 10;
        [Range(0, 10)] [SerializeField] public float battleCryChance = 50;
        [Range(0, 10)] [SerializeField] public float customLineChance = 50;
        [Range(0, 10)] [SerializeField] public float laughChance = 50;
        [Range(0, 10)] [SerializeField] public float deathChance = 50;
    }

    [SerializeField] public SpeechSFXSettings speechSFXSettings;
}
