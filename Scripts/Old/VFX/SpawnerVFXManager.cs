using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerVFXManager : MonoBehaviour
{
    [SerializeField] protected Material spawnMaterial;

    public class SpawnerVFXState
    {
        public bool isSpawnVFXActive;
        public float threshold = -1f;

        public void SetSpawnerVFXState(bool isSpawnVFXActive = false)
        {
            this.isSpawnVFXActive = isSpawnVFXActive;
            if (!isSpawnVFXActive)
            {
                this.threshold = -1f;
                manager.spawnMaterial.SetFloat("_threshold", -1f);
            }
        }
    }

    [System.Serializable]
    public class SpawnerVFXSettings
    {
        public float spawnSpeed = 1f;
        public float spawnDuration = 2f;
    }

    public SpawnerVFXSettings spawnerVFXSettings;

    [System.NonSerialized] public SpawnerVFXState spawnerVFXState;

    [System.NonSerialized] public static SpawnerVFXManager manager;

    public static void SetSpawnVFXActive() => manager.spawnerVFXState.SetSpawnerVFXState(isSpawnVFXActive: true);

    public static void SetSpawnVFXDeactive() => manager.spawnerVFXState.SetSpawnerVFXState(isSpawnVFXActive: false);

    public static float IncreaseThreshold() => manager.spawnerVFXState.threshold += manager.spawnerVFXSettings.spawnSpeed * Time.deltaTime;

    public static void UpdateThreshold() => manager.spawnMaterial.SetFloat("_threshold", IncreaseThreshold());

    private void Start()
    {
        spawnerVFXState = new SpawnerVFXState();
        manager = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnerVFXState.isSpawnVFXActive) UpdateThreshold();
    }
}
