using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyAttackBehaviourSettings
{
    [System.Serializable]
    public class AttackBehaviour
    {
        [SerializeField] public enum AttackBehaviourType { Normal, Combo, Rage, Skill }
        [SerializeField] public AttackBehaviourType attackBehaviourType;

        [SerializeField] public string animationName;

        [SerializeField] public int attackChance = 3;
        [SerializeField] public float recoveryTime = 2f;

        [SerializeField] public float maximumAttackAngle = 35;
        [SerializeField] public float minimumAttackAngle = -35;

        [SerializeField] public float minimumDistanceNeededToAttack = 0f;
        [SerializeField] public float maximumDistanceNeededToAttack = 3f;
    }

    [SerializeField] public List<AttackBehaviour> attackBehaviours;
}
