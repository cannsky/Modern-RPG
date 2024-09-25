using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManaSphere
{
    public class ManaSphereState
    {
        public PlayerWorker playerWorker;

        public PlayerSphereSettings sphereSettings;

        public GameObject manaSphereGameObject;

        public Material manaSphereMaterial;

        public ManaSphereState(PlayerWorker playerWorker, PlayerSphereSettings sphereSettings)
        {
            this.playerWorker = playerWorker;
            this.sphereSettings = sphereSettings;
            manaSphereGameObject = sphereSettings.manaSphereSettings.manaSphereGameObject;
        }

        public void InitializeManaSphereState() => manaSphereMaterial = manaSphereGameObject.GetComponent<Image>().material;
    }

    public ManaSphereState manaSphereState;

    public PlayerManaSphere(PlayerWorker playerWorker) => manaSphereState = new ManaSphereState(playerWorker, playerWorker.player.playerSettings.sphereSettings);

    public void UpdateManaSphereFillStatus()
    {
        manaSphereState.manaSphereMaterial.SetFloat("_FillLevel",
            (float)(manaSphereState.playerWorker.playerStats.statsState.playerManaStats.manaStatsState.currentMana /
            manaSphereState.playerWorker.playerStats.statsState.playerManaStats.manaStatsState.maxMana));
    }
}
