using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSFXSettings
{
    [System.Serializable]
    public class FootstepSFXSettings
    {
        [SerializeField] public List<AudioClip> footstepAudioClips;
        [SerializeField] public AudioSource footstepAudioSource;
    }

    [System.Serializable]
    public class SlashSFXSettings
    {
        [SerializeField] public List<AudioClip> slashAudioClips;
        [SerializeField] public AudioSource slashAudioSource;
    }

    [System.Serializable]
    public class TrailSFXSettings
    {
        [SerializeField] public List<AudioClip> trailAudioClips;
        [SerializeField] public AudioSource trailAudioSource;
    }

    [SerializeField] public FootstepSFXSettings footstepSFXSettings;
    [SerializeField] public SlashSFXSettings slashSFXSettings;
    [SerializeField] public TrailSFXSettings trailSFXSettings;
}
