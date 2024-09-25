using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyTypeSettings
{
    public enum Type
    {
        Archer,
        Priest,
        Warrior,
        Witch,
        Giant,
        Dragon,
        Boss
    }

    [SerializeField] public Type type;

    [SerializeField] public EnemyMovementTypeSettings movementTypeSettings;
}
