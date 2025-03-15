using System.Collections;
using UnityEngine;

public class ItemZone : MonoBehaviour
{
    [SerializeField] private Item _item;
    [SerializeField] private float transferInterval = 1f;

    private Inventory _targetInventory;
    private int _targetItemindex;

    public Item GetZoneItem()
    {
        return _item;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            _targetItemindex = inventory.FindItem(_item.Name);
            _targetInventory = inventory;
            StartCoroutine(AddItem());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory) && inventory == _targetInventory)
        {
            _targetInventory = null;
        }
    }

    private IEnumerator AddItem()
    {
        while (_targetInventory != null)
        {
            _targetInventory.AddItemByIndex(_targetItemindex);
            yield return new WaitForSeconds(transferInterval);
        }
    }
}
