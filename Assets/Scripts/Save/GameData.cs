using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class GameData
{
    public PlayerData PlayerData;
    public List<BuildingData> Buildings;
}

[System.Serializable]
public class PlayerData
{
    public Vector3 Position;
    public int Money;
    public float CarrySpeed;
    public Inventory.InvItem[] InventoryData;

    public PlayerData() { }

    public PlayerData(PlayerData other)
    {
        CarrySpeed = other.CarrySpeed;
        Money = other.Money;
        Position = other.Position;
        InventoryData = other.InventoryData.ToArray();
    }
}

[System.Serializable]
public class BuildingData
{
    public string BuildingID;
    public bool IsPurchased;
    public Inventory.InvItem[] InventoryData;
}
