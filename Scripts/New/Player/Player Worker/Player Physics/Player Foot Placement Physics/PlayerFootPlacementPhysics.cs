using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootPlacementPhysics
{
    public class FootPlacementPhysicsState
    {
        public PlayerWorker playerWorker;

        public PlayerFootPlacementPhysicsSettings footPlacementPhysicsSettings;

        public JUFootPlacement juFootPlacement;

        public FootPlacementPhysicsState(PlayerWorker playerWorker, PlayerFootPlacementPhysicsSettings footPlacementPhysicsSettings)
        {
            this.playerWorker = playerWorker;
            this.footPlacementPhysicsSettings = footPlacementPhysicsSettings;
            juFootPlacement = footPlacementPhysicsSettings.juFootPlacemet;
        }
    }

    public FootPlacementPhysicsState footPlacementPhysicsState;

    public PlayerFootPlacementPhysics(PlayerWorker playerWorker) => footPlacementPhysicsState = new FootPlacementPhysicsState(playerWorker, playerWorker.player.playerSettings.physicsSettings.footPlacementPhysicsSettings);

    public void Update() => HandleFootPlacement();

    public void HandleFootPlacement()
    {
        if (footPlacementPhysicsState.playerWorker.playerStats.statsState.playerActionStats.CheckFootPlacementAvailable())
        {
            footPlacementPhysicsState.juFootPlacement.enabled = true;
        }
        else footPlacementPhysicsState.juFootPlacement.enabled = false;
    }
}
