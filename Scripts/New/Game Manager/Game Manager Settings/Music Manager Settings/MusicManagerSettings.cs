using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MusicManagerSettings
{
    [SerializeField] public AudioSource backgroundMusicAudioSource;
    [SerializeField] [Range(0, 100)] public float backgroundMusicVolume;
    [SerializeField] public List<AudioClip> battleAudioClips, travelAudioClips, villageAudioClips, eventAudioClips, ambianceClips;
}
