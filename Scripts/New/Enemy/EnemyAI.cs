using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public EnemySettings enemySettings;

    public EnemyWorker enemyWorker;

    private void Awake() => enemyWorker = new EnemyWorker(this, null);

    private void Start() => enemyWorker.StartCall();

    private void Update() => enemyWorker.UpdateCall();

    private void FixedUpdate() => enemyWorker.FixedUpdateCall();

    private void LateUpdate() => enemyWorker.LateUpdateCall();

    public void DestroyItself() => Destroy(gameObject);

    public Transform InstantiateEnemyRelatedGameObject(Transform instantiatedTransform, Vector3 position, Quaternion rotation) => Instantiate(instantiatedTransform, position, rotation);
}