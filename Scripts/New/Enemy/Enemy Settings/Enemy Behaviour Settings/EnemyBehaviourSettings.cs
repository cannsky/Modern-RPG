using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBehaviourSettings
{

    [System.Serializable]
    public class BehaviourIntelligenceSettings
    {
        public enum Intelligence { VeryUnintelligent, Unintelligent, Normal, Intelligent, VeryIntelligent }

        public Intelligence intelligence;
    }

    [SerializeField] public BehaviourIntelligenceSettings behaviourIntelligenceSettings;

    [SerializeField] public EnemyAttackBehaviourSettings attackBehaviourSettings;

    [SerializeField] public EnemyChaseBehaviourSettings chaseBehaviourSettings;

    [SerializeField] public EnemyCombatStanceBehaviourSettings combatStanceBehaviourSettings;

    [SerializeField] public EnemyIdleBehaviourSettings idleBehaviourSettings;

    [SerializeField] public EnemyRotateBehaviourSettings rotateBehaviourSettings;


    [System.Serializable]
    public class DefenseBehaviourSettings
    {
        public enum DefenseBehaviourType { Normal, Block, Dodge, Protect }

        public List<DefenseBehaviourType> defenseBehaviours;
    }

    [SerializeField] public DefenseBehaviourSettings defenseBehaviourSettings;
}
