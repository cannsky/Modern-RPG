using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyMovementSettings
{
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] public float stopDistance = 2f;

    [System.Serializable]
    public class EnemyRigidbodyMovementSettings
    {
        [SerializeField] public Rigidbody rigidbody;
        [SerializeField] public float runMovementSpeed = 4f;
        [SerializeField] public float damageMovementSpeed = 4f;
    }

    [SerializeField] public EnemyRigidbodyMovementSettings enemyRigidbodyMovementSettings;
}