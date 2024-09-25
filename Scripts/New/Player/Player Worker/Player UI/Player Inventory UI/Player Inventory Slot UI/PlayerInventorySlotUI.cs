using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventorySlotUI
{
    public class InventorySlotUIState
    {
        public PlayerWorker playerWorker;

        public PlayerInventorySlotUISettings playerInventorySlotUISettings;

        public GameObject inventorySlotsGameObject, inventorySlotGameObject, inventorySlotPrefab;

        public InventorySlotUIState(PlayerWorker playerWorker, PlayerInventorySlotUISettings playerInventorySlotUISettings)
        {
            this.playerWorker = playerWorker;
            this.playerInventorySlotUISettings = playerInventorySlotUISettings;
            inventorySlotsGameObject = playerInventorySlotUISettings.inventorySlotsGameObject;
            inventorySlotPrefab = playerInventorySlotUISettings.inventorySlotPrefab;
            playerWorker.player.InstantiatePlayerUIGameObject(inventorySlotPrefab, Vector3.zero, Quaternion.identity, inventorySlotsGameObject.transform);
        }
    }

    public InventorySlotUIState inventorySlotUIState;

    public PlayerInventorySlotUI(PlayerWorker playerWorker) => inventorySlotUIState = new InventorySlotUIState(playerWorker, playerWorker.player.playerSettings.uiSettings.inventoryUISettings.inventorySlotUISettings);

}
