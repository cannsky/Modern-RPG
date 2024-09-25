using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class EnemyRotationSettings
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float rotationSpeed = 15f;
}
