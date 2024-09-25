using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerTrailVFX;

public class PlayerWeaponHitVFX
{
    public class WeaponHitVFXState
    {
        public PlayerWorker playerWorker;

        public PlayerVFXSettings vfxSettings;

        public List<GameObject> weaponHitVFXList = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public Transform parent;

        public WeaponHitVFXState(PlayerWorker playerWorker, PlayerVFXSettings vfxSettings)
        {
            this.playerWorker = playerWorker;
            this.vfxSettings = vfxSettings;
        }
    }

    public WeaponHitVFXState weaponHitVFXState;

    public PlayerWeaponHitVFX(PlayerWorker playerWorker) => weaponHitVFXState = new WeaponHitVFXState(playerWorker, playerWorker.player.playerSettings.vfxSettings);

    public void UpdateWeaponHitVFXParent()
    {
        if (weaponHitVFXState.parent != null) Debug.Log("SET PARENT VFX TO DISABLED!");
        weaponHitVFXState.parent = weaponHitVFXState.playerWorker.playerWeapon.weaponState.playerWeaponHolder.
        GetCurrentWeaponGameObject().transform.
        GetChild(1).
            GetChild(weaponHitVFXState.vfxSettings.weaponHitVFXSettings.weaponHitVFXIndex).
            GetChild(weaponHitVFXState.playerWorker.playerStats.statsState.playerElementStats.elementStatsState.element);
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
        weaponHitVFXState.currentVFXTransform = weaponHitVFXState.playerWorker.player.InstantiatePlayerVFXGameObject(
            weaponHitVFXState.parent,
            collidedObjectTransform.position,
            weaponHitVFXState.parent.rotation);
        weaponHitVFXState.currentVFXTransform.gameObject.SetActive(true);
        if (!weaponHitVFXState.currentVFXTransform) return;
        foreach (Transform vfx in weaponHitVFXState.currentVFXTransform) EnableVFX(vfx);
    }
}
