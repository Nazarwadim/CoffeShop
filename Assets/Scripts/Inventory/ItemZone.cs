using UnityEngine;

public class ItemZone : MonoBehaviour
{
    [SerializeField] private Item _item;

    public Item GetZoneItem()
    {
        return _item;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            int index = inventory.FindItem(_item.Name);
            inventory.TryAddItemByIndex(index);
        }
    }
}
