using System.Linq;
using UnityEngine;

public class BuildingZone : MonoBehaviour
{
    [SerializeField] private GameObject _building;
    [SerializeField] private GameObject _buildingGhost;
    [SerializeField] private int _cost;
    [SerializeField] private string _buildingID;

    public string BuildingID => _buildingID;

    public bool IsPurcahsed
    {
        get { return _building.activeSelf; }
        private set
        {
            _building.SetActive(value);
            _buildingGhost.SetActive(!value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!IsPurcahsed && other.TryGetComponent(out IBuildingBuyer buildingBuyer) && buildingBuyer.CanAffordBuilding(_cost))
        {
            buildingBuyer.PurchaseBuilding(_cost);
            IsPurcahsed = true;
        }
    }

    public BuildingData GetBuildingData()
    {
        bool hasInventory = _building.TryGetComponent(out Inventory inventory);

        return new BuildingData()
        {
            BuildingID = _buildingID,
            IsPurchased = IsPurcahsed,
            InventoryData = hasInventory ? inventory.GetItems().ToArray() : null,
        };
    }

    public void SetBuildingData(BuildingData buildingData)
    {
        bool hasInventory = _building.TryGetComponent(out Inventory inventory);

        IsPurcahsed = buildingData.IsPurchased;
        if (hasInventory)
        {
            inventory.SetItems(buildingData.InventoryData);
        }
    }
}
