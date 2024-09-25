using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonChest : MonoBehaviour
{
    //public List<DictionaryNode<Consumable, int>> items;
    int count;
    void Start()
    {
        count = UnityEngine.Random.Range(10000, 100000);
    }

    public void OnChestOpened()
    {
        /*
        DictionaryNode<Consumable, int> item = items[Random.Range(0, items.Count)];
        Consumable consumable = Instantiate<Consumable>(item.firstElement);
        consumable.ResetCooldown();

        Slot slot = new Slot(consumable, item.secondElement, count++);
        consumable.slot = slot;
        HotBarUIManager.Instance.Add(consumable);
        */
    }
}
