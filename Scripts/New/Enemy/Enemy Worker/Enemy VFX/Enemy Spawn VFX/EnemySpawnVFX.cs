using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnVFX : MonoBehaviour
{
    public class SpawnVFXState
    {
        public EnemyWorker enemyWorker;

        public EnemyVFXSettings vfxSettings;

        public List<GameObject> vfxs = new List<GameObject>();
        public Transform currentVFXTransform;
        public ParticleSystem currentVfx;
        public ParticleSystem.EmissionModule emission;

        public SpawnVFXState(EnemyWorker enemyWorker, EnemyVFXSettings vfxSettings)
        {
            this.enemyWorker = enemyWorker;
            this.vfxSettings = vfxSettings;
            UpdateEnemyVFX();
        }

        public void UpdateEnemyVFX()
        {
            foreach (Transform vfx in vfxSettings.spawnVFXSettings.vfxParent.transform) vfxs.Add(vfx.gameObject);
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

    public SpawnVFXState spawnVFXState;

    public EnemySpawnVFX(EnemyWorker enemyWorker) => spawnVFXState = new SpawnVFXState(enemyWorker, enemyWorker.enemyAI.enemySettings.vfxSettings);

    public void PlayVFX(EnemyVFXSettings.VfxType vfxType)
    {
        if (!spawnVFXState.vfxSettings.spawnVFXSettings.isSpawnVFXActive) return;
        spawnVFXState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isSpawning = true;
        spawnVFXState.enemyWorker.enemyAI.StartCoroutine(EndVFX());
        spawnVFXState.enemyWorker.enemyAI.enemyWorker.enemyMaterial.ReverseDissolve();
        StartVFX((int)vfxType);
    }

    public IEnumerator EndVFX()
    {
        yield return new WaitForSeconds(spawnVFXState.vfxSettings.spawnVFXSettings.spawnVFXDuration);
        spawnVFXState.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isSpawning = false;
        StopVFX();
    }

    public void StartVFX(int vfxID)
    {
        /*spawnVFXState.currentVFXTransform = Instantiate(spawnVFXState.vfxs[vfxID].transform.GetChild((int)spawnVFXState.enemyWorker.enemyAI.stats.element),
            spawnVFXState.vfxs[vfxID].transform.GetChild((int)spawnVFXState.enemyWorker.enemyAI.stats.element).position,
            spawnVFXState.vfxs[vfxID].transform.GetChild((int)spawnVFXState.enemyWorker.enemyAI.stats.element).rotation);
        */
        spawnVFXState.currentVfx = spawnVFXState.currentVFXTransform.GetComponent<ParticleSystem>();
        spawnVFXState.currentVfx.Play();
        spawnVFXState.emission = spawnVFXState.currentVfx.emission;
        spawnVFXState.emission.enabled = true;
    }

    public void StopVFX()
    {
        if (!spawnVFXState.currentVfx) return;
        spawnVFXState.emission = spawnVFXState.currentVfx.emission;
        spawnVFXState.emission.enabled = false;
        Destroy(spawnVFXState.currentVfx.gameObject);
    }
}