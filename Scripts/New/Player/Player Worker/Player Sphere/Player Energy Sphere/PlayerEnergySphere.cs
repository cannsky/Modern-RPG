using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergySphere
{
    public class EnergySphereState
    {
        public PlayerWorker playerWorker;

        public PlayerSphereSettings sphereSettings;

        public GameObject energySphereGameObject;

        public Material energySphereMaterial;

        public EnergySphereState(PlayerWorker playerWorker, PlayerSphereSettings sphereSettings)
        {
            this.playerWorker = playerWorker;
            this.sphereSettings = sphereSettings;
            energySphereGameObject = sphereSettings.energySphereSettings.energySphereGameObject;
        }

        public void InitializeEnergySphereState() => energySphereMaterial = energySphereGameObject.GetComponent<Image>().material;
    }

    public EnergySphereState energySphereState;

    public PlayerEnergySphere(PlayerWorker playerWorker) => energySphereState = new EnergySphereState(playerWorker, playerWorker.player.playerSettings.sphereSettings);

    public void UpdateEnergySphereFillStatus()
    {
        energySphereState.energySphereMaterial.SetFloat("_FillLevel",
            (float)(energySphereState.playerWorker.playerStats.statsState.playerEnergyStats.energyStatsState.currentEnergy /
            energySphereState.playerWorker.playerStats.statsState.playerEnergyStats.energyStatsState.maxEnergy));
    }
}
