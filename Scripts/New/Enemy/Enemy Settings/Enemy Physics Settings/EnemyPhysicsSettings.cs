using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPhysicsSettings
{
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public float gravityMultiplier = -9.81f;
    [SerializeField] public float fallingSpeed = 45f;
    [SerializeField] public float groundDetectionRayStartPoint = 0.32f;
    [SerializeField] public float minimumDistanceNeededToBeginFall = 1f;
    [SerializeField] public float groundDirectionRayDistance = 0.2f;
}
