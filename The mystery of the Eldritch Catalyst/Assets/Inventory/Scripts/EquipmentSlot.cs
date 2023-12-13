using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemData _item;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private ItemActionSystem itemActionsSystem;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_item != null)
        {
            TooltipSystem.Instance.Show(_item.description, _item.name);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Instance.Hide();
    }

    public void ClickOnSlot()
    {
        if (_item != null)
        {
            DesequipEquipment();
        }
    }

    public void EquipEquipment(ItemData equipment)
    {
        _item = equipment;
        _itemIcon.sprite = equipment.icon;
        Inventory.Instance.RemoveItem(equipment);
        Inventory.Instance.RefreshContent();
    }

    public void DesequipEquipment()
    {
        if (_item != null && !Inventory.Instance.InventoryIsFull())
        {
            
            _itemIcon.sprite = Inventory.Instance.GetTransparentSlot();
            Inventory.Instance.AddItem(_item);
            Inventory.Instance.RefreshContent();
            _item = null;
        }
    }

    public void SwapEquipment(ItemData equipment)
    {
        Inventory.Instance.RemoveItem(equipment);
        Inventory.Instance.AddItem(_item);
        _item = equipment;
        _itemIcon.sprite = equipment.icon;
        Inventory.Instance.RefreshContent();
    }

    public ItemData GetItem() { return _item; }
}