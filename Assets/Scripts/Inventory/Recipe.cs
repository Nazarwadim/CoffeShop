using System;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Inventory/Recipe")]
public class Recipe : ScriptableObject
{
    public Inventory.InvItem[] ItemsNeeded;
    public Inventory.InvItem ResultItem;

    public bool CanCraft(Inventory inventory)
    {
        if (inventory == null) return false;

        foreach (var item in ItemsNeeded)
        {
            var itemInInventory = inventory.FindItem(item.Item);
            if (itemInInventory == null || itemInInventory.Count < item.Count)
            {
                return false;
            }
        }

        var resultItemInInventory = inventory.FindItem(ResultItem.Item);

        if(resultItemInInventory.Count >= resultItemInInventory.MaxCount)
        {
            return false;
        }

        return true;
    }

    public void Craft(Inventory inventory)
    {
        if (!CanCraft(inventory))
        {
            throw new Exception("Can`t craft an item");
        }

        foreach (var item in ItemsNeeded)
        {
            inventory.RemoveItem(item);
        }

        inventory.AddItem(ResultItem);
    }
}
