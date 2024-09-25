using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDodgeSettings
{
    [SerializeField] public float baseDodgeChance = 25, dodgeChanceIncrease = 10, checkDodgeInterval = 2.5f;
}
