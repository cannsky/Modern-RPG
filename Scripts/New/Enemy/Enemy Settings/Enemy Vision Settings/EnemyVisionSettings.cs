using UnityEngine;

[System.Serializable]
public class EnemyVisionSettings
{
    [SerializeField] public LayerMask playerLayer;
    [SerializeField] public float sightRange = 25f;
    [SerializeField] public float cautionRange = 10f;
    [SerializeField] public float attackRange = 4f;
}
