using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerAttackControl;

public class PlayerUIControl
{
    public class UIControlState
    {
        public PlayerWorker playerWorker;

        public PlayerControl.ControlState controlState;

        public PlayerControlSettings controlSettings;

        public bool characterInput, inventoryInput;

        public UIControlState(PlayerWorker playerWorker, PlayerControlSettings controlSettings)
        {
            this.playerWorker = playerWorker;
            this.controlSettings = controlSettings;
        }

        public void InitializeAttackControlState(PlayerControl playerControl) => controlState = playerControl.controlState;
    }

    public UIControlState uiControlState;

    public PlayerUIControl(PlayerWorker playerWorker) => uiControlState = new UIControlState(playerWorker, playerWorker.player.playerSettings.controlSettings);

    public void Start() => SetUiInput();

    public void Update() => HandleUiInput();

    public void LateUpdate()
    {
        uiControlState.characterInput = false;
        uiControlState.inventoryInput = false;
    }

    public void SetUiInput()
    {
        uiControlState.controlState.inputActions.PlayerUI.PlayerCharacter.performed += i => uiControlState.characterInput = true;
        uiControlState.controlState.inputActions.PlayerUI.PlayerInventory.performed += i => uiControlState.inventoryInput = true;
    }

    public void HandleUiInput()
    {
        if (uiControlState.characterInput) uiControlState.playerWorker.playerUI.uiState.playerInventoryUI.ToggleUI();
        else if (uiControlState.inventoryInput) uiControlState.playerWorker.playerUI.uiState.playerInventoryUI.ToggleUI();
    }
}
