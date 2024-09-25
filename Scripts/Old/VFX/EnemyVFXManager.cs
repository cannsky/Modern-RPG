using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVFXManager : MonoBehaviour
{
    [SerializeField] protected Material originalMaterial;
    [SerializeField] protected Material spawnMaterial;
    [SerializeField] protected Renderer meshRenderer;

    public GameObject eventVFXParent;
    private List<GameObject> vfxs = new List<GameObject>();
    Transform currentSkillVFXTransform;
    ParticleSystem currentSkillVfx;
    ParticleSystem.EmissionModule emission;
    EnemyAI enemyAI;

    private void OnEnable() => StartSpawnVFX();

    private void OnDisable() => EndSpawnVFX();

    void StartSpawnVFX()
    {
        if (vfxs.Count == 0) UpdateEnemyVFX();
        enemyAI.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isSpawning = true;
        PlaySkillVFX(1);
        meshRenderer.materials = new Material[] { spawnMaterial };
        SpawnerVFXManager.SetSpawnVFXActive();
        Invoke("EndSpawnVFX", SpawnerVFXManager.manager.spawnerVFXSettings.spawnDuration);
    }

    void EndSpawnVFX()
    {
        enemyAI.enemyWorker.enemyStats.statsState.enemyActionStats.actionStatsState.isSpawning = false;
        StopSkillVFX();
        meshRenderer.materials = new Material[] { originalMaterial };
        SpawnerVFXManager.SetSpawnVFXDeactive();
    }

    void UpdateEnemyVFX()
    {
        enemyAI = transform.parent.parent.GetComponent<EnemyAI>();
        foreach (Transform vfx in eventVFXParent.transform) vfxs.Add(vfx.gameObject);
        foreach (GameObject vfx in vfxs)
        {
            foreach (Transform vfxType in vfx.transform)
            {
                var particles = vfxType.GetComponent<ParticleSystem>();
                particles.Stop();
                var emis = particles.emission;
                emis.enabled = false;
            }
        }
    }

    public void PlaySkillVFX(int skillValue)
    {
        //currentSkillVFXTransform = Instantiate(vfxs[skillValue - 1].transform.GetChild((int)stats.element), vfxs[skillValue - 1].transform.GetChild((int)stats.element).position, vfxs[skillValue - 1].transform.GetChild((int)stats.element).rotation);
        currentSkillVfx = currentSkillVFXTransform.GetComponent<ParticleSystem>();
        currentSkillVfx.Play();
        emission = currentSkillVfx.emission;
        emission.enabled = true;
    }

    public void StopSkillVFX()
    {
        if (!currentSkillVfx)
            return;

        emission = currentSkillVfx.emission;
        emission.enabled = false;
        Destroy(currentSkillVfx.gameObject);
    }

}
