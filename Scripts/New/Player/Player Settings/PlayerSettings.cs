using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    [System.Serializable]
    public class PlayerSettings
    {
        [SerializeField] public PlayerAnimationSettings animationSettings;
        [SerializeField] public PlayerAttackSettings attackSettings;
        [SerializeField] public PlayerCameraSettings cameraSettings;
        [SerializeField] public PlayerCombatTechniqueSettings combatTechniqueSettings;
        [SerializeField] public PlayerControlSettings controlSettings;
        [SerializeField] public PlayerDamageSettings damageSettings;
        [SerializeField] public PlayerFixerSettings fixerSettings;
        [SerializeField] public PlayerInventorySettings inventorySettings;
        [SerializeField] public PlayerMovementSettings movementSettings;
        [SerializeField] public PlayerPhysicsSettings physicsSettings;
        [SerializeField] public PlayerSFXSettings sfxSettings;
        [SerializeField] public PlayerSphereSettings sphereSettings;
        [SerializeField] public PlayerStanceSettings stanceSettings;
        [SerializeField] public PlayerStatsSettings statsSettings;
        [SerializeField] public PlayerUISettings uiSettings;
        [SerializeField] public PlayerVFXSettings vfxSettings;
        [SerializeField] public PlayerWeaponSettings weaponSettings;
    }
}