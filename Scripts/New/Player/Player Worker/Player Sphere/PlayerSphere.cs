using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSphere
{
    public class SphereState
    {
        public PlayerWorker playerWorker;

        public PlayerSphereSettings sphereSettings;

        public PlayerEnergySphere playerEnergySphere;
        public PlayerHealthSphere playerHealthSphere;
        public PlayerHolyPowerSphere playerHolyPowerSphere;
        public PlayerManaSphere playerManaSphere;

        public SphereState(PlayerWorker playerWorker, PlayerSphereSettings sphereSettings)
        {
            this.playerWorker = playerWorker;
            this.sphereSettings = sphereSettings;
            playerEnergySphere = new PlayerEnergySphere(playerWorker);
            playerHealthSphere = new PlayerHealthSphere(playerWorker);
            playerHolyPowerSphere = new PlayerHolyPowerSphere(playerWorker);
            playerManaSphere = new PlayerManaSphere(playerWorker);
        }

        public void InitializeSphereState()
        {
            playerEnergySphere.energySphereState.InitializeEnergySphereState();
            playerHealthSphere.healthSphereState.InitializeHealthSphereState();
            playerHolyPowerSphere.holyPowerSphereState.InitializeEnergySphereState();
            playerManaSphere.manaSphereState.InitializeManaSphereState();
        }
    }

    public SphereState sphereState;

    public PlayerSphere(PlayerWorker playerWorker) => sphereState = new SphereState(playerWorker, playerWorker.player.playerSettings.sphereSettings);

    public void Start() => sphereState.InitializeSphereState();
}
