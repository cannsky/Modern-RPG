using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    [CreateAssetMenu(menuName = "Mandeshire/Item/Potion Item/Mana Potion Item")]
    public class ManaPotionItem : PotionItem
    {
        [Header("Health Potion Item Information")]
        public float increaseAmount;
    }
}