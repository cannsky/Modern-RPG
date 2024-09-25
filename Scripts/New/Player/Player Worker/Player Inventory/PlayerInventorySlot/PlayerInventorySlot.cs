using System.Collections;
using System.Collections.Generic;
using Mandeshire;
using UnityEngine;

public class PlayerInventorySlot
{
    public class InventorySlotState
    {
        public PlayerWorker playerWorker;

        public PlayerInventorySlotSettings inventorySlotSettings;

        public PlayerInventorySlotUI inventorySlotUI;

        public Item item;

        public InventorySlotState(PlayerWorker playerWorker, PlayerInventorySlotSettings inventorySlotSettings)
        {
            this.playerWorker = playerWorker;
            this.inventorySlotSettings = inventorySlotSettings;
            inventorySlotUI = playerWorker.playerUI.uiState.playerInventoryUI.CreateInventorySlotUI();
        }
    }

    public InventorySlotState inventorySlotState;

    public PlayerInventorySlot(PlayerWorker playerWorker) => inventorySlotState = new InventorySlotState(playerWorker, playerWorker.player.playerSettings.inventorySettings.inventorySlotSettings);
}
