using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI
{
    public class UIState
    {
        public PlayerWorker playerWorker;

        public PlayerUISettings uiSettings;

        public PlayerCursorUI playerCursorUI;
        public PlayerInventoryUI playerInventoryUI;

        public UIState(PlayerWorker playerWorker, PlayerUISettings uiSettings)
        {
            this.playerWorker = playerWorker;
            this.uiSettings = uiSettings;
            playerCursorUI = new PlayerCursorUI(playerWorker);
            playerInventoryUI = new PlayerInventoryUI(playerWorker);
        }
    }

    public UIState uiState;

    public PlayerUI(PlayerWorker playerWorker) => uiState = new UIState(playerWorker, playerWorker.player.playerSettings.uiSettings);

    public void Start() => uiState.playerCursorUI.Start();

    public bool CheckUIOpened() => uiState.playerInventoryUI.inventoryUIState.uiVisibility;
}
