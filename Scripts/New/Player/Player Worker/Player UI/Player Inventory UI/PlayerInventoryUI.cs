using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI
{
    public class InventoryUIState
    {
        public PlayerWorker playerWorker;

        public PlayerInventoryUISettings playerInventoryUISettings;

        public List<PlayerInventorySlotUI> playerInventorySlotUIList;

        public GameObject inventoryUIGameObject;

        public bool uiVisibility;

        public InventoryUIState(PlayerWorker playerWorker, PlayerInventoryUISettings playerInventoryUISettings)
        {
            this.playerWorker = playerWorker;
            this.playerInventoryUISettings = playerInventoryUISettings;
            inventoryUIGameObject = playerInventoryUISettings.inventoryUIGameObject;
            playerInventorySlotUIList = new List<PlayerInventorySlotUI>();
        }
    }

    public InventoryUIState inventoryUIState;

    public PlayerInventoryUI(PlayerWorker playerWorker) => inventoryUIState = new InventoryUIState(playerWorker, playerWorker.player.playerSettings.uiSettings.inventoryUISettings);

    public void ToggleUI()
    {
        inventoryUIState.inventoryUIGameObject.SetActive(inventoryUIState.uiVisibility = !inventoryUIState.uiVisibility);
        inventoryUIState.playerWorker.playerUI.uiState.playerCursorUI.ToggleCursor();
    }

    public PlayerInventorySlotUI CreateInventorySlotUI()
    {
        inventoryUIState.playerInventorySlotUIList.Add(new PlayerInventorySlotUI(inventoryUIState.playerWorker));
        return inventoryUIState.playerInventorySlotUIList[inventoryUIState.playerInventorySlotUIList.Count - 1];
    }
}
