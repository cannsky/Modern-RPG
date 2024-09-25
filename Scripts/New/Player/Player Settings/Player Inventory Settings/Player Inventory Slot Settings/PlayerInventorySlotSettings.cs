using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInventorySlotSettings
{
    [SerializeField] public int defaultUnlockedInventorySlotCount = 25, defaultLockedInventorySlotCount = 55;
}
