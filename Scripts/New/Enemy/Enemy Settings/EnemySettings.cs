using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySettings
{
    [SerializeField] public EnemyAgentSettings agentSettings;
    [SerializeField] public EnemyAnimationSettings animationSettings;
    [SerializeField] public EnemyAttackSettings attackSettings;
    [SerializeField] public EnemyBarSettings barSettings;
    [SerializeField] public EnemyBehaviourSettings behaviourSettings;
    [SerializeField] public EnemyCameraSettings cameraSettings;
    [SerializeField] public EnemyDamageSettings damageSettings;
    [SerializeField] public EnemyDeathSettings deathSettings;
    [SerializeField] public EnemyDetectionSettings detectionSettings;
    [SerializeField] public EnemyDodgeSettings dodgeSettings;
    [SerializeField] public EnemyLootSettings lootSettings;
    [SerializeField] public EnemyMaterialSettings materialSettings;
    [SerializeField] public EnemyRotationSettings rotationSettings;
    [SerializeField] public EnemyMovementSettings movementSettings;
    [SerializeField] public EnemyParrySettings parrySettings;
    [SerializeField] public EnemyPhysicsSettings physicsSettings;
    [SerializeField] public EnemySFXSettings sfxSettings;
    [SerializeField] public EnemySpeechSettings speechSettings;
    [SerializeField] public EnemyStatsSettings statsSettings;
    [SerializeField] public EnemyTriggerSettings triggerSettings;
    [SerializeField] public EnemyTypeSettings typeSettings;
    [SerializeField] public EnemyVFXSettings vfxSettings;
    [SerializeField] public EnemyVisionSettings visionSettings;
    [SerializeField] public EnemyWeaponSettings weaponSettings;
}
