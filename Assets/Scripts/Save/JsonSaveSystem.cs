using UnityEngine;
using System.Collections.Generic;

public class JsonSaveSystem
{
    private static readonly string SaveFile = "save";

    private readonly Player _player;
    private readonly PlayerConfig _playerStartConfig;

    public JsonSaveSystem(Player player, PlayerConfig playerStartConfig)
    {
        _player = player;
        _playerStartConfig = playerStartConfig;
    }

    public void Save()
    {
        List<BuildingData> buildings = new();

        foreach (BuildingZone building in Object.FindObjectsOfType<BuildingZone>())
        {
            buildings.Add(building.GetBuildingData());
        }

        GameData gameData = new()
        {
            PlayerData = _player.GetPlayerData(),
            Buildings = buildings
        };

        JsonSaver<GameData>.Save(gameData, SaveFile);
    }

    public void Load()
    {
        bool loaded = JsonSaver<GameData>.TryLoad(SaveFile, out GameData gameData);
        if (!loaded)
        {
            _player.Initialize(_playerStartConfig.PlayerData);
            return;
        }

        _player.Initialize(gameData.PlayerData);
        foreach (BuildingZone building in Object.FindObjectsOfType<BuildingZone>())
        {
            foreach (BuildingData buildingData in gameData.Buildings)
            {
                if (buildingData.BuildingID == building.BuildingID)
                {
                    building.SetBuildingData(buildingData);
                }
            }
        }

    }
}
