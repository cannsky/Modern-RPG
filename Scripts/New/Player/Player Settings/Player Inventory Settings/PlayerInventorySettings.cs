using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventorySettings
{
    [SerializeField] public PlayerInventorySlotSettings inventorySlotSettings;
    [SerializeField] public int defaultUnlockedInventorySlotCount = 25, defaultLockedInventorySlotCount = 55;
}
