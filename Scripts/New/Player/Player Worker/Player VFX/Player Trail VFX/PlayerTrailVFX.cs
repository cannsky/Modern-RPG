using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrailVFX
{
    public class TrailVFXState
    {
        public PlayerWorker playerWorker;

        public PlayerVFXSettings vfxSettings;

        public Transform parent, trail, glow, particle;

        public bool isTrailHandlerStopped;

        public float trailDisableDelayTime, trailDisableDelayCounter;

        public TrailVFXState(PlayerWorker playerWorker, PlayerVFXSettings vfxSettings)
        {
            this.playerWorker = playerWorker;
            this.vfxSettings = vfxSettings;
            trailDisableDelayTime = vfxSettings.trailVFXSettings.trailDisableDelayTime;
        }
    }

    public TrailVFXState trailVFXState;

    public PlayerTrailVFX(PlayerWorker playerWorker) => trailVFXState = new TrailVFXState(playerWorker, playerWorker.player.playerSettings.vfxSettings);

    public void UpdateTrailVFXParent()
    {
        if(trailVFXState.parent != null) Debug.Log("SET PARENT VFX TO DISABLED!");
        trailVFXState.parent = trailVFXState.playerWorker.playerWeapon.weaponState.playerWeaponHolder.
            GetCurrentWeaponGameObject().transform.
            GetChild(0).
            GetChild(trailVFXState.vfxSettings.trailVFXSettings.trailVFXIndex).
            GetChild(trailVFXState.playerWorker.playerStats.statsState.playerElementStats.elementStatsState.element);
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
