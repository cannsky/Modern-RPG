using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerInventorySlotUI;

public class PlayerInventory
{
    public class InventoryState
    {
        public PlayerWorker playerWorker;

        public PlayerInventorySettings inventorySettings;

        public List<PlayerInventorySlot> inventorySlots, lockedInventorySlots;

        public int unlockedInventorySlotCount, lockedInventorySlotCount;

        public InventoryState(PlayerWorker playerWorker, PlayerInventorySettings inventorySettings)
        {
            this.playerWorker = playerWorker;
            this.inventorySettings = inventorySettings;
            unlockedInventorySlotCount = inventorySettings.defaultUnlockedInventorySlotCount;
            lockedInventorySlotCount = inventorySettings.defaultLockedInventorySlotCount;
            inventorySlots = new List<PlayerInventorySlot>();
            lockedInventorySlots = new List<PlayerInventorySlot>();
        }
    }

    public InventoryState inventoryState;

    public PlayerInventory(PlayerWorker playerWorker) => inventoryState = new InventoryState(playerWorker, playerWorker.player.playerSettings.inventorySettings);

    public void Start()
    {
        LoadUnlockedSlots();
        LoadLockedSlots();
    }

    public void LoadUnlockedSlots()
    {
        for (int i = 0; i < inventoryState.unlockedInventorySlotCount; i++) inventoryState.inventorySlots.Add(new PlayerInventorySlot(inventoryState.playerWorker));
    }

    public void LoadLockedSlots()
    {
        for (int j = 0; j < inventoryState.lockedInventorySlotCount; j++) inventoryState.lockedInventorySlots.Add(new PlayerInventorySlot(inventoryState.playerWorker));
    }
}
