using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private PlayerData _playerData;

    public PlayerData PlayerData => new(_playerData);
}
