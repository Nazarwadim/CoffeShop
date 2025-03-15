using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Texture;
    public GameObject Prefab;
}
