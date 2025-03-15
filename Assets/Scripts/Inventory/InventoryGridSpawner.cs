using UnityEngine;

public class InventoryGridSpawner : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private float _horizontalOffset;
    [SerializeField] private float _verticalOffset;

    private void OnEnable()
    {
        _inventory.InventoryChanged += SpawnItems;
    }

    private void OnDisable()
    {
        _inventory.InventoryChanged -= SpawnItems;
    }

    private void Start()
    {
        SpawnItems();
    }

    private void SpawnItems()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        int columnIndex = 0;

        foreach (var invItem in _inventory.GetItems())
        {
            if (invItem.Item.Prefab != null)
            {
                for (int i = 0; i < invItem.Count; i++)
                {
                    Vector3 position = GetPosition(columnIndex, i);
                    Transform prefab = Instantiate(invItem.Item.Prefab, transform).transform;
                    prefab.localPosition = position;
                }
                columnIndex++;
            }
        }
    }

    private Vector3 GetPosition(int column, int row)
    {
        return new Vector3(column * _horizontalOffset, row * _verticalOffset, 0);
    }
}
