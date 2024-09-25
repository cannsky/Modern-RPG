using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public float spawnRange;
        public int size;
        public int level;
    }

    [System.Serializable]
    public class PooledObjects
    {
        public string tag;
        public List<GameObject> objects;
        public PooledObjects(string tag)
        {
            this.tag = tag;
        }
    }

    [System.Serializable]
    public class SpawnerState
    {
        public bool isSpawnerStarted;
        public int spawnerLevel = 1;
        public int activeEnemiesCount;
    }

    [System.Serializable]
    public class SpawnerSettings
    {
        public int maxLevel;
        public AudioClip startAudio;
        public AudioClip endAudio;
        public AudioClip battleMusic;
    }

    public List<Pool> pools;
    public List<PooledObjects> pooledLists = new List<PooledObjects>();
    public SpawnerState spawnerState;
    public SpawnerSettings spawnerSettings;
    public OldSpawnerLevelEnd spawnerLevelEndEventTrigger;
    public SpawnerTrigger spawnerTrigger;

    private void Start()
    {
        spawnerState = new SpawnerState();
        spawnerState.spawnerLevel = 1;
    }

    public void SpawnEnemy()
    {
        SpawnerSFXManager.PlaySpawnerAudio(spawnerSettings.startAudio);
        SpawnerSFXManager.PlaySpawnerBackgroundMusic(spawnerSettings.battleMusic);
        spawnerState.isSpawnerStarted = true;
        int index = 0;
        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            pooledLists.Add(new PooledObjects(pool.tag));
            foreach (PooledObjects pooledObjects in pooledLists)
            {
                if (pooledObjects.tag == pool.tag)
                {
                    pooledObjects.objects = new List<GameObject>();
                    for (int i = 0; i < pool.size; i++)
                    {
                        GameObject obj = Instantiate(pool.prefab, new Vector3(transform.position.x + Random.Range(-pool.spawnRange, pool.spawnRange), transform.position.y, transform.position.z + Random.Range(-pool.spawnRange, pool.spawnRange)), Quaternion.identity);
                        obj.SetActive(false);
                        objectPool.Enqueue(obj);
                        pooledObjects.objects.Add(obj);
                        //obj.GetComponent<EnemyAI>().spawner = this;
                    }
                }
            }
        }
    }

    public void SetEnemiesActive()
    {
        spawnerState.activeEnemiesCount = 0;
        foreach (Pool pool in pools)
        {
            spawnerState.activeEnemiesCount += pool.size;
            foreach (PooledObjects pooledObjects in pooledLists)
                if (pooledObjects.tag == pool.tag) foreach (GameObject enemyObject in pooledObjects.objects) enemyObject.SetActive(true);
        }
    }

    public void SetEnemiesDeactive()
    {
        foreach (PooledObjects pooledObjects in pooledLists)
            foreach (GameObject enemyObject in pooledObjects.objects) enemyObject.SetActive(false);
    }

    public void SetEnemyDeactive()
    {
        if (--spawnerState.activeEnemiesCount == 0)
        {
            if (spawnerState.spawnerLevel == 0) transform.GetChild(0).gameObject.SetActive(true);
            if (spawnerSettings.maxLevel == spawnerState.spawnerLevel)
            {
                spawnerTrigger.StopSpawnerTriggerVFX();
                SpawnerSFXManager.StopSpawnerBackgroundMusic();
                SpawnerSFXManager.PlaySpawnerAudio(spawnerSettings.endAudio);
                spawnerLevelEndEventTrigger.EndLevel();
            }
            else spawnerTrigger.UpdateSpawnerTriggerVFX(++spawnerState.spawnerLevel);
        }
    }
}
