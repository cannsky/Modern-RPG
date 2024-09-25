using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStatsSettings
{
    [System.Serializable]
    public class PlayerElementStatsSettings
    {
        public enum Element
        {
            Water,
            Fire,
            Air,
            Earth
        }
        [SerializeField] public Element element;
    }

    [System.Serializable]
    public class PlayerEnergyStatsSettings
    {
        [SerializeField] public int energyLevel = 10;
        [SerializeField] public int energyLevelMultiplier = 10;
    }

    [System.Serializable]
    public class PlayerHealthStatsSettings
    {
        [SerializeField] public int healthLevel = 10;
        [SerializeField] public int healthLevelMultiplier = 10;
    }

    [System.Serializable]
    public class PlayerHolyPowerStatsSettings
    {
        [SerializeField] public int holyPowerLevel = 10;
        [SerializeField] public int holyPowerLevelMultiplier = 10;
    }

    [System.Serializable]
    public class PlayerManaStatsSettings
    {
        [SerializeField] public int manaLevel = 10;
        [SerializeField] public int manaLevelMultiplier = 10;
    }

    [System.Serializable]
    public class PlayerMultiplierStatsSettings
    {
        [SerializeField] public float healthRegenerationMultiplier = 1;
        [SerializeField] public float energyRegenerationMultiplier = 1;

        [SerializeField] public float attackEnergyDecreaseMultiplier = 2;
        [SerializeField] public float sprintEnergyDecreaseMultiplier = 4;
        [SerializeField] public float rollEnergyDecreaseMultiplier = 20;
    }

    [SerializeField] public PlayerElementStatsSettings elementStatsSettings;
    [SerializeField] public PlayerEnergyStatsSettings energyStatsSettings;
    [SerializeField] public PlayerHealthStatsSettings healthStatsSettings;
    [SerializeField] public PlayerHolyPowerStatsSettings holyPowerStatsSettings;
    [SerializeField] public PlayerManaStatsSettings manaStatsSettings;
    [SerializeField] public PlayerMultiplierStatsSettings multiplierStatsSettings;
}
