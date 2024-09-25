using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour
{
    public GameObject spawnerVFXParent;
    private List<GameObject> vfxs = new List<GameObject>();
    Transform currentSpawnerVFXTransform;
    ParticleSystem currentSpawnerVFX;
    ParticleSystem.EmissionModule emission;

    void Start()
    {
        foreach (Transform vfx in spawnerVFXParent.transform) vfxs.Add(vfx.gameObject);
        PlaySpawnerTriggerVFX(0);
    }

    public void PlaySpawnerTriggerVFX(int vfxValue)
    {
        currentSpawnerVFXTransform = vfxs[vfxValue].transform;
        currentSpawnerVFXTransform.gameObject.SetActive(true);
        currentSpawnerVFX = currentSpawnerVFXTransform.GetComponent<ParticleSystem>();
        currentSpawnerVFX.Play();
        emission = currentSpawnerVFX.emission;
        emission.enabled = true;
    }

    public void StopSpawnerTriggerVFX()
    {
        if (!currentSpawnerVFX)
            return;

        emission = currentSpawnerVFX.emission;
        emission.enabled = false;
        currentSpawnerVFX.gameObject.SetActive(false);
        currentSpawnerVFXTransform.gameObject.SetActive(false);
    }


    public void UpdateSpawnerTriggerVFX(int spawnerLevel)
    {
        StopSpawnerTriggerVFX();
        gameObject.SetActive(true);
        PlaySpawnerTriggerVFX(spawnerLevel-1);
    }
}
