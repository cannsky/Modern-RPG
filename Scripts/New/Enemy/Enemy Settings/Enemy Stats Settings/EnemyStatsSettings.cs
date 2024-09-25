using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyStatsSettings
{
    [System.Serializable]
    public class EnemyElementStatsSettings
    {
        public enum Element { Water, Fire, Air, Earth }

        [SerializeField] public Element element;
    }

    [SerializeField] public EnemyElementStatsSettings elementStatsSettings;

    [System.Serializable]
    public class EnemyHealthStatsSettings
    {
        [SerializeField] public int healthLevel = 10;
        [SerializeField] public int healthLevelMultiplier = 10;
    }

    [SerializeField] public EnemyHealthStatsSettings healthStatsSettings;

    [System.Serializable]
    public class EnemyMultiplierStatsSettings
    {
        [SerializeField] public float healthRegenerationMultiplier = 1;
    }

    [SerializeField] public EnemyMultiplierStatsSettings multiplierStatsSettings;
}
