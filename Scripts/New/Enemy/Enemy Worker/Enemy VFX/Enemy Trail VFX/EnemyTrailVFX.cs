using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrailVFX
{
    public class TrailVFXState
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public Transform parent, trail, glow, particle;

        public TrailVFXState(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
        }
    }

    public TrailVFXState trailVFXState;

    public EnemyTrailVFX(EnemyWorker enemyWorker) => trailVFXState = new TrailVFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);

    public void UpdateTrailVFXParent()
    {
        if (trailVFXState.parent != null) Debug.Log("SET PARENT VFX TO DISABLED!");
        trailVFXState.parent = trailVFXState.enemyWorker.enemyWeapon.weaponState.enemyWeaponHolder.
            GetCurrentWeaponGameObject().transform.
            GetChild(0).
            GetChild(trailVFXState.vfxSettings.trailVFXSettings.trailVFXIndex).
            GetChild(trailVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element);
        DisableVFX(trailVFXState.trail = trailVFXState.parent.GetChild(0));
        DisableVFX(trailVFXState.glow = trailVFXState.parent.GetChild(1));
        DisableVFX(trailVFXState.particle = trailVFXState.parent.GetChild(2));
    }

    public void EnableTrails()
    {
        EnableVFX(trailVFXState.trail);
        EnableVFX(trailVFXState.glow);
        EnableVFX(trailVFXState.particle);
    }

    public void DisableTrails()
    {
        DisableVFX(trailVFXState.trail);
        DisableVFX(trailVFXState.glow);
        DisableVFX(trailVFXState.particle);
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
}
