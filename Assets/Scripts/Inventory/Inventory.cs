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

    [SerializeField] private InvItem[] _items;

    public IEnumerable<InvItem> GetItems()
    {
        foreach (var item in _items)
        {
            yield return item;
        }
    }

    public int FindItem(string name)
    {
        return Array.FindIndex(_items, item => item.Item.Name == name);
    }

    public InvItem FindItem(Item item)
    {
        int index = FindItem(item.name);
        if (index >= 0)
        {
            return _items[index];
        }
        else
        {
            return null;
        }
    }

    public void MoveItemsToOtherInventory(Inventory other)
    {
        if (other == null)
        {
            return;
        }

        int itemIndex = 0;
        foreach (var item in GetItems())
        {
            if (item.Count > 0)
            {
                int index = other.FindItem(item.Item.Name);
                var otherItem = other._items[index];
                if (otherItem.Count < otherItem.MaxCount)
                {
                    other.AddItemByIndex(index);
                    RemoveItemByIndex(itemIndex);
                }
            }
            itemIndex++;
        }
    }

    public void AddItemByIndex(int itemIndex)
    {
        if (_items[itemIndex].Count < _items[itemIndex].MaxCount)
        {
            _items[itemIndex].Count++;
            InventoryChanged?.Invoke();
        }
    }

    public void RemoveItemByIndex(int itemIndex)
    {
        if (_items[itemIndex].Count > 0)
        {
            _items[itemIndex].Count--;
            InventoryChanged?.Invoke();
        }
    }

    public int GetTotalItemsCount()
    {
        int sum = 0;
        foreach (InvItem item in _items)
        {
            sum += item.Count;
        }
        return sum;
    }

    public void RemoveItem(InvItem item)
    {
        int index = FindItem(item.Item.name);
        if (index >= 0)
        {
            if (_items[index].Count >= item.Count)
            {
                _items[index].Count -= item.Count;
                InventoryChanged?.Invoke();
            }
        }
    }

    public void RemoveItem(Item item)
    {
        int index = FindItem(item.name);
        if (index >= 0)
        {
            RemoveItemByIndex(index);
        }
    }

    public void AddItem(InvItem item)
    {
        int index = FindItem(item.Item.name);
        if (index >= 0)
        {
            if (_items[index].Count + item.Count <= _items[index].MaxCount)
            {
                _items[index].Count += item.Count;
                InventoryChanged?.Invoke();
            }
        }
    }
}
