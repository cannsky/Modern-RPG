using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mandeshire
{
    [CreateAssetMenu(menuName = "Mandeshire/Item/Weapon Item")]
    public class WeaponItem : Item
    {
        [Header("Weapon Item Information")]
        public int weaponIndex;
    }
}