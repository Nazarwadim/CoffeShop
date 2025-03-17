using UnityEngine;
using UnityEngine.UI;

public class InventoryItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _countText;

    public void Setup(Inventory.InvItem item)
    {
        _icon.sprite = item.Item.Texture;
        _countText.text = "x" + item.Count;
    }
}
