using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovementSettings
{
    [Header("Rigidbody Movement")]
    [SerializeField] public Rigidbody rigidbody;
    [SerializeField] public Transform cameraTransform;
    [SerializeField] public float runMovementSpeed = 10f;
    [SerializeField] public float sprintMovementSpeed = 14f;
    [Header("Rotation Movement")]
    [SerializeField] public float rotationSpeed = 10f;
    [SerializeField] public float lockedPivotPosition = 2.25f;
    [SerializeField] public float unlockedPivotPosition = 1.65f;
    [Header("Fall Movement")]
    [SerializeField] public float gravityMultiplier = -9.81f;
    [SerializeField] public float fallingSpeed = 45f;
    [SerializeField] public float groundDetectionRayStartPoint = 0.32f;
    [SerializeField] public float minimumDistanceNeededToBeginFall = 1f;
    [SerializeField] public float groundDirectionRayDistance = 0.2f;
    [Header("Attack Movement")]
    [SerializeField] public float attackMovementSpeed = 5f;
}
