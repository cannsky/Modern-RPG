using System.Collections.Generic;
using UnityEngine;

public class EnemySkillVFX : MonoBehaviour
{
    public class SkillVFXState
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public List<GameObject> vfxs = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public SkillVFXState(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
            UpdateVFX();
        }

        public void UpdateVFX()
        {
            foreach (Transform vfx in vfxSettings.skillVFXSettings.vfxParent.transform) vfxs.Add(vfx.gameObject);
            foreach (GameObject vfx in vfxs) foreach (Transform vfxType in vfx.transform) DisableVFX(vfxType);
        }

        public void DisableVFX(Transform vfxType)
        {
            var particles = vfxType.GetComponent<ParticleSystem>();
            particles.Stop();
            var emis = particles.emission;
            emis.enabled = false;
        }
    }

    public SkillVFXState skillVFXState;

    public EnemySkillVFX(EnemyWorker enemyWorker) => skillVFXState = new SkillVFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);

    public void PlayVFX(int vfxValue)
    {
        skillVFXState.currentVFXTransform = Instantiate(
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element),
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element).position,
            skillVFXState.vfxs[vfxValue - 1].transform.GetChild((int)skillVFXState.enemyWorker.enemyStats.statsState.enemyElementStats.elementStatsState.element).rotation);

        skillVFXState.currentVFXTransform.gameObject.SetActive(true);
        skillVFXState.currentVfx = skillVFXState.currentVFXTransform.GetComponent<ParticleSystem>();
        skillVFXState.currentVfx.Play();
        skillVFXState.emission = skillVFXState.currentVfx.emission;
        skillVFXState.emission.enabled = true;
    }
}
