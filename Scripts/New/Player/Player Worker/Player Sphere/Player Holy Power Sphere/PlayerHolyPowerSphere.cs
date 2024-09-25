using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHolyPowerSphere
{
    public class HolyPowerSphereState
    {
        public PlayerWorker playerWorker;

        public PlayerSphereSettings sphereSettings;

        public GameObject holyPowerSphereGameObject;

        public Material holyPowerSphereMaterial;

        public HolyPowerSphereState(PlayerWorker playerWorker, PlayerSphereSettings sphereSettings)
        {
            this.playerWorker = playerWorker;
            this.sphereSettings = sphereSettings;
            holyPowerSphereGameObject = sphereSettings.holyPowerSphereSettings.holyPowerSphereGameObject;
        }

        public void InitializeEnergySphereState() => holyPowerSphereMaterial = holyPowerSphereGameObject.GetComponent<Image>().material;
    }

    public HolyPowerSphereState holyPowerSphereState;

    public PlayerHolyPowerSphere(PlayerWorker playerWorker) => holyPowerSphereState = new HolyPowerSphereState(playerWorker, playerWorker.player.playerSettings.sphereSettings);

    public void UpdateHolyPowerSphereFillStatus()
    {
        holyPowerSphereState.holyPowerSphereMaterial.SetFloat("_FillLevel",
            (float)(holyPowerSphereState.playerWorker.playerStats.statsState.playerHolyPowerStats.holyPowerStatsState.currentHolyPower /
            holyPowerSphereState.playerWorker.playerStats.statsState.playerHolyPowerStats.holyPowerStatsState.maxHolyPower));
    }
}
