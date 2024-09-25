using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    public class Item : ScriptableObject
    {
        [Header("General Item Information")]
        public Sprite itemIcon;
        public string itemID;
        public string itemName;
        [Header("World Item Information")]
        public GameObject lootItemGameObject;
    }
}