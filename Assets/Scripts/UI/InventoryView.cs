using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _contentPanel;
    [SerializeField] private GameObject _itemUIPrefab;

    private readonly List<GameObject> _itemSlots = new List<GameObject>();

    private void OnEnable()
    {
        _inventory.InventoryChanged += UpdateUI;
    }

    private void OnDisable()
    {
        _inventory.InventoryChanged -= UpdateUI;
    }

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        foreach (var slot in _itemSlots)
        {
            Destroy(slot);
        }
        _itemSlots.Clear();

        foreach (var item in _inventory.GetItems())
        {
            GameObject newItemUI = Instantiate(_itemUIPrefab, _contentPanel);
            newItemUI.GetComponent<InventoryItemView>().Setup(item);
            _itemSlots.Add(newItemUI);
        }
    }
}
