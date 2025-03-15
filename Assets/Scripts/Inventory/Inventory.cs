using UnityEngine;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public event Action InventoryChanged;

    [Serializable]
    public class InvItem
    {
        public Item Item;
        public int Count;
        public int MaxCount;
    }

    [SerializeField] private InvItem[] Items;

    public IEnumerable<InvItem> GetItems()
    {
        foreach (var item in Items)
        {
            yield return item;
        }
    }

    public int FindItem(string name)
    {
        return Array.FindIndex(Items, item => item.Item.Name == name);
    }

    public bool TryAddItemByIndex(int itemIndex)
    {
        if (Items[itemIndex].Count < Items[itemIndex].MaxCount)
        {
            Items[itemIndex].Count++;
            InventoryChanged?.Invoke();
            return true;
        }
        return false;
    }
}
