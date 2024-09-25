using UnityEngine;

[System.Serializable]
public class EnemyVFXSettings
{
    public enum VfxType { Spawn, Attack, Death }

    [System.Serializable]
    public class SkillVFXSettings
    {
        public GameObject vfxParent;
    }

    [SerializeField] public SkillVFXSettings skillVFXSettings;

    [System.Serializable]
    public class DissolveVFXSettings
    {
        public GameObject vfxParent;
    }

    [SerializeField] public DissolveVFXSettings dissolveVFXSettings;

    [System.Serializable]
    public class SpawnVFXSettings
    {
        public GameObject vfxParent;
        public bool isSpawnVFXActive;
        public float spawnVFXSpeed = 1f;
        public float spawnVFXDuration = 2f;
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
