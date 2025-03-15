using UnityEngine;
using System.Collections;
using System.Linq;

public class InventoryTransfer : MonoBehaviour
{
    [SerializeField] private Inventory _currentInventory;
    [SerializeField] private float transferInterval = 1f;

    private Inventory _targetInventory;
    private Coroutine _transferCoroutine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory))
        {
            _targetInventory = inventory;

            if (_transferCoroutine == null)
            {
                _transferCoroutine = StartCoroutine(TransferItemsRoutine());
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Inventory inventory) && inventory == _targetInventory)
        {
            _targetInventory = null;

            if (_transferCoroutine != null)
            {
                StopCoroutine(_transferCoroutine);
                _transferCoroutine = null;
            }
        }
    }

    private IEnumerator TransferItemsRoutine()
    {
        while (_targetInventory != null)
        {
            TransferItems();
            yield return new WaitForSeconds(transferInterval);
        }
    }

    private void TransferItems()
    {
        if (_currentInventory == null)
        {
            return;
        }

        _targetInventory.MoveItemsToOtherInventory(_currentInventory);
    }
}
