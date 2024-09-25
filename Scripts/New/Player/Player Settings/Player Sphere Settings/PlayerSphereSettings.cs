using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSphereSettings
{
    [System.Serializable]
    public class PlayerEnergySphereSettings
    {
        [SerializeField] public GameObject energySphereGameObject;
    }

    [System.Serializable]
    public class PlayerHealthSphereSettings
    {
        [SerializeField] public GameObject healthSphereGameObject;
    }

    [System.Serializable]
    public class PlayerHolyPowerSphereSettings
    {
        [SerializeField] public GameObject holyPowerSphereGameObject;
    }

    [System.Serializable]
    public class PlayerManaSphereSettings
    {
        [SerializeField] public GameObject manaSphereGameObject;
    }

    [SerializeField] public PlayerEnergySphereSettings energySphereSettings;
    [SerializeField] public PlayerHealthSphereSettings healthSphereSettings;
    [SerializeField] public PlayerHolyPowerSphereSettings holyPowerSphereSettings;
    [SerializeField] public PlayerManaSphereSettings manaSphereSettings;
}
