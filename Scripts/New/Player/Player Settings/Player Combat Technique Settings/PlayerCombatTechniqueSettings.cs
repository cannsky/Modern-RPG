using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerCombatTechniqueSettings
{
    [System.Serializable]
    public class CombatTechnique
    {
        [System.Serializable]
        public class CombatTechniqueAttack
        {
            [SerializeField] public string animationName;
            [SerializeField] public float damageMultiplier = 1f;
        }

        [System.Serializable] public enum CombatTechniqueType { Normal, LightningSpeed, RockDurability, WaterVortex }
        [SerializeField] public CombatTechniqueType type;
        [SerializeField] public UnityEngine.UI.Image icon;
        [SerializeField] public List<CombatTechniqueAttack> combatTechniqueAttacks;
    }

    [SerializeField] public float combatTechniqueAttackComboResetTime = 1f;
    [SerializeField] public List<CombatTechnique> combatTechniques;
    [SerializeField] public CombatTechnique.CombatTechniqueType defaultCombatTechnique;
}
