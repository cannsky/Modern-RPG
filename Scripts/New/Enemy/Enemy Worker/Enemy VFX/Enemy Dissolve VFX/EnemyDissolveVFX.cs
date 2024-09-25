using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDissolveVFX : MonoBehaviour
{
    public class DissolveVFXSettings
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public List<GameObject> vfxs = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public DissolveVFXSettings(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
            UpdateVFX();
        }

        public void UpdateVFX()
        {
            foreach (Transform vfx in vfxSettings.dissolveVFXSettings.vfxParent.transform) vfxs.Add(vfx.gameObject);
            foreach (GameObject vfx in vfxs) foreach (Transform vfxType in vfx.transform) DisableVFX(vfxType.GetChild(1));
        }

        public void DisableVFX(Transform vfxType)
        {
            var particles = vfxType.GetComponent<ParticleSystem>();
            particles.Stop();
            var emis = particles.emission;
            emis.enabled = false;
        }
    }

    public DissolveVFXSettings skillVFXState;

    public EnemyDissolveVFX(EnemyWorker enemyWorker) => skillVFXState = new DissolveVFXSettings(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);

    public void PlayVFX(int vfxValue)
    {
        skillVFXState.currentVFXTransform = Instantiate(
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element).GetChild(1),
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element).GetChild(1).position,
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element).GetChild(1).rotation);

        skillVFXState.currentVFXTransform.gameObject.SetActive(true);
        skillVFXState.currentVfx = skillVFXState.currentVFXTransform.GetComponent<ParticleSystem>();
        skillVFXState.currentVfx.Play();
        skillVFXState.emission = skillVFXState.currentVfx.emission;
        skillVFXState.emission.enabled = true;
    }
}
