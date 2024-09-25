using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackVFX : MonoBehaviour
{
    public class AttackVFXState
    {
        public PlayerWorker playerWorker;

        public PlayerVFXSettings vfxSettings;

        public List<GameObject> slashVFXList = new List<GameObject>();
        public List<GameObject> skillVFXList = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public AttackVFXState(PlayerWorker playerWorker, PlayerVFXSettings vfxSettings)
        {
            this.playerWorker = playerWorker;
            this.vfxSettings = vfxSettings;
            UpdateVFX();
        }

        public void UpdateVFX()
        {
            foreach (Transform vfx in vfxSettings.slashVFXSettings.vfxParent.transform) slashVFXList.Add(vfx.gameObject);
            foreach (Transform vfx in vfxSettings.skillVFXSettings.vfxParent.transform) skillVFXList.Add(vfx.gameObject);
            foreach (GameObject vfx in slashVFXList) foreach (Transform vfxType in vfx.transform) DisableVFX(vfxType);
            foreach (GameObject vfx in skillVFXList) foreach (Transform vfxType in vfx.transform) DisableVFX(vfxType);
        }

        public void DisableVFX(Transform vfxType)
        {
            var particles = vfxType.GetComponent<ParticleSystem>();
            particles.Stop();
            var emis = particles.emission;
            emis.enabled = false;
        }
    }

    public AttackVFXState attackVFXState;

    public PlayerAttackVFX(PlayerWorker playerWorker) => attackVFXState = new AttackVFXState(playerWorker, playerWorker.player.playerSettings.vfxSettings);

    public List<GameObject> GetVFXList(PlayerVFXSettings.VfxType vfxType)
    {
        return vfxType switch
        {
            PlayerVFXSettings.VfxType.Slash => attackVFXState.slashVFXList,
            PlayerVFXSettings.VfxType.Skill => attackVFXState.skillVFXList,
            _ => null
        };
    }

    public Transform GetTransform(PlayerVFXSettings.VfxType vfxType, int vfxID) => Instantiate(
        GetVFXList(vfxType)[vfxID - 1].transform.GetChild(attackVFXState.playerWorker.playerStats.statsState.playerElementStats.elementStatsState.element),
        GetVFXList(vfxType)[vfxID - 1].transform.GetChild(attackVFXState.playerWorker.playerStats.statsState.playerElementStats.elementStatsState.element).position,
        GetVFXList(vfxType)[vfxID - 1].transform.GetChild(attackVFXState.playerWorker.playerStats.statsState.playerElementStats.elementStatsState.element).rotation);

    public void StartVFX(PlayerVFXSettings.VfxType vfxType, int vfxID)
    {
        attackVFXState.currentVFXTransform = GetTransform(vfxType, vfxID);
        attackVFXState.currentVFXTransform.gameObject.SetActive(true);
        attackVFXState.currentVfx = attackVFXState.currentVFXTransform.GetComponent<ParticleSystem>();
        attackVFXState.currentVfx.Play();
        attackVFXState.emission = attackVFXState.currentVfx.emission;
        attackVFXState.emission.enabled = true;
    }
}
