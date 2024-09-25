using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSphere
{
    public class HealthSphereState
    {
        public PlayerWorker playerWorker;

        public PlayerSphereSettings sphereSettings;

        public GameObject healthSphereGameObject;

        public Material healthSphereMaterial;

        public HealthSphereState(PlayerWorker playerWorker, PlayerSphereSettings sphereSettings)
        {
            this.playerWorker = playerWorker;
            this.sphereSettings = sphereSettings;
            healthSphereGameObject = sphereSettings.healthSphereSettings.healthSphereGameObject;
        }

        public void InitializeHealthSphereState() => healthSphereMaterial = healthSphereGameObject.GetComponent<Image>().material;
    }

    public HealthSphereState healthSphereState;

    public PlayerHealthSphere(PlayerWorker playerWorker) => healthSphereState = new HealthSphereState(playerWorker, playerWorker.player.playerSettings.sphereSettings);

    public void UpdateHealthSphereFillStatus()
    {
        healthSphereState.healthSphereMaterial.SetFloat("_FillLevel",
            (float) (healthSphereState.playerWorker.playerStats.statsState.playerHealthStats.healthStatsState.currentHealth /
            healthSphereState.playerWorker.playerStats.statsState.playerHealthStats.healthStatsState.maxHealth));
    }
}
