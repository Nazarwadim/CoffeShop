using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _texture;
    [SerializeField] private GameObject _prefab;

    public string Name => _name;
    public Sprite Texture => _texture;
    public GameObject Prefab => _prefab;
}
