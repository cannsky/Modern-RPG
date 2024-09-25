using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollControl
{
    public class RollControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControl.ControlState controlState;

        public PlayerControlSettings controlSettings;

        public RollControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
        }

        public void InitializeRollControlState(PlayerControl playerControl) => controlState = playerControl.controlState;
    }

    public RollControlState rollControlState;

    public PlayerRollControl(PlayerWorker playerWorker) => rollControlState = new RollControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start()
    {
        return;
    }

    public void Update() => HandleRollInput(Time.deltaTime);

    public void HandleRollInput(float delta)
    {
        rollControlState.controlState.bInput = rollControlState.controlState.inputActions.PlayerActions.Roll.phase == UnityEngine.InputSystem.InputActionPhase.Performed;
        if (rollControlState.controlState.bInput)
        {
            rollControlState.controlState.rollInputTimer += delta;
            rollControlState.controlState.sprintFlag = true;
        }
        else
        {
            if (rollControlState.controlState.rollInputTimer > 0 && rollControlState.controlState.rollInputTimer < 0.5f)
            {
                rollControlState.controlState.sprintFlag = false;
                rollControlState.controlState.rollFlag = true;
            }

            rollControlState.controlState.rollInputTimer = 0;
        }
    }
}
