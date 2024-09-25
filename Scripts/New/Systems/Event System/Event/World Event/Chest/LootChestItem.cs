using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event/World Event/Chest Event/Loot Chest Item", order = 3)]
public class LootChestItem : WorldEvent
{
    public override bool HandleEvent()
    {
        if (base.isEffectItSelf)
            if (!LootItem(base.gameObjectSelf.transform.parent.parent.parent.parent.gameObject)) return false;
        return true;
    }

    public bool LootItem(GameObject gameObject)
    {
        gameObject.GetComponent<DungeonChest>().OnChestOpened();
        return true;
    }
}
