using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerVFXSettings
{
    public enum VfxType { Spawn, Death, Slash, Skill, Hit }

    [System.Serializable]
    public class HitVFXSettings {
        [SerializeField] public GameObject vfxParent; 
    }

    [SerializeField] public HitVFXSettings hitVFXSettings;

    [System.Serializable]
    public class SkillVFXSettings {
        [SerializeField] public GameObject vfxParent; 
    }

    [SerializeField] public SkillVFXSettings skillVFXSettings;

    [System.Serializable]
    public class SlashVFXSettings {
        [SerializeField] public GameObject vfxParent;
    }

    [SerializeField] public SkillVFXSettings slashVFXSettings;

    [System.Serializable]
    public class SpawnVFXSettings
    {
        [SerializeField] public GameObject vfxParent;
        [SerializeField] public bool isSpawnVFXActive;
        [SerializeField] public float spawnVFXSpeed = 1f;
        [SerializeField] public float spawnVFXDuration = 2f;
    }

    [SerializeField] public SpawnVFXSettings spawnVFXSettings;

    [System.Serializable]
    public class TrailVFXSettings
    {
        [SerializeField] public int trailVFXIndex;
        [SerializeField] public float trailDisableDelayTime = 2f;
    }

    [SerializeField] public TrailVFXSettings trailVFXSettings;

    [System.Serializable]
    public class WeaponHitVFXSettings
    {
        [SerializeField] public int weaponHitVFXIndex;
    }

    [SerializeField] public WeaponHitVFXSettings weaponHitVFXSettings;
}
