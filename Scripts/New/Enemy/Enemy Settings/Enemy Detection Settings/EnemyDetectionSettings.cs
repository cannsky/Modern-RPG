using UnityEngine;

[System.Serializable]
public class EnemyDetectionSettings
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public float raycastSightRange = 5f;
    [SerializeField] public float raycastWaitTime = 1f;
    [SerializeField] public int raycastAngleThreshold = 1;
}
