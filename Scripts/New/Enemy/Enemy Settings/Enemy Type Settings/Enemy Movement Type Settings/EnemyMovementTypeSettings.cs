using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyMovementTypeSettings
{
    public enum MovementType
    {
        Cautious,
        Medium,
        Agressive
    }

    [SerializeField] public MovementType movementType;
}
