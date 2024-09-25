using System.Collections;
using System.Collections.Generic;
using Mandeshire;
using UnityEngine;

[System.Serializable]
public class ItemLootPackageElement
{
    [SerializeField] public Item item;
    [Range(0f, 100f)] public float dropChance;
}
