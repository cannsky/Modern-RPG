using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponHitVFX
{
    public class WeaponHitVFXState
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public List<GameObject> weaponHitVFXList = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public Transform parent;

        public WeaponHitVFXState(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
        }
    }

    public WeaponHitVFXState weaponHitVFXState;

    public EnemyWeaponHitVFX(EnemyWorker enemyWorker) => weaponHitVFXState = new WeaponHitVFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);

    public void UpdateWeaponHitVFXParent()
    {
        if (weaponHitVFXState.parent != null) Debug.Log("SET PARENT VFX TO DISABLED!");
        weaponHitVFXState.parent = weaponHitVFXState.enemyWorker.enemyWeapon.weaponState.enemyWeaponHolder.
            GetCurrentWeaponGameObject().transform.
            GetChild(1).
            GetChild(weaponHitVFXState.vfxSettings.weaponHitVFXSettings.weaponHitVFXIndex).
            GetChild(weaponHitVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element);
        foreach (Transform vfx in weaponHitVFXState.parent) DisableVFX(vfx);
    }

    public void EnableVFX(Transform vfxType)
    {
        var particles = vfxType.GetComponent<ParticleSystem>();
        particles.Play();
        var emis = particles.emission;
        emis.enabled = true;
    }

    public void DisableVFX(Transform vfxType)
    {
        var particles = vfxType.GetComponent<ParticleSystem>();
        particles.Stop();
        var emis = particles.emission;
        emis.enabled = false;
    }

    public void PlayHitVFX(Transform collidedObjectTransform)
    {
        weaponHitVFXState.currentVFXTransform = weaponHitVFXState.enemyWorker.enemyAI.InstantiateEnemyRelatedGameObject(
            weaponHitVFXState.parent,
            collidedObjectTransform.position,
            weaponHitVFXState.parent.rotation);
        weaponHitVFXState.currentVFXTransform.gameObject.SetActive(true);
        if (!weaponHitVFXState.currentVFXTransform) return;
        foreach (Transform vfx in weaponHitVFXState.currentVFXTransform) EnableVFX(vfx);
    }
}
