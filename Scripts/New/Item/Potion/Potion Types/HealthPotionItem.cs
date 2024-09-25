using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    [CreateAssetMenu(menuName = "Mandeshire/Item/Potion Item/Health Potion Item")]
    public class HealthPotionItem : PotionItem
    {
        [Header("Health Potion Item Information")]
        public float increaseAmount;
    }
}