using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private ItemData _item;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private ItemActionSystem _itemActionsSystem;
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

    public void setItem(ItemData item)
    {
        _item = item;
    }

    public void setItemIcon(Sprite itemIcon)
    {
        _itemIcon.sprite = itemIcon;
    }

    public void ClickOnSlot()
    {
        _itemActionsSystem.OpenActionPanel(_item);
    }
}