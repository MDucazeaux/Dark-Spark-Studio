using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//using static UnityEditor.Progress;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private ItemData _item;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private ItemActionSystem _itemActionsSystem;

    private Transform _transform;

    public void Start()
    {
        _transform = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_item != null)
        {
            string content = _item.GetDescription();
            switch (_item.GetItemType())
            {
                case ItemType.Armor:
                    content += "\n\nStats :\nArmor = " + _item.GetArmorStats();
                    break;
                case ItemType.Weapon:
                    content += "\n\nStats :\nPhysical Strength = " + _item.GetPhysicalStrengthStats() + "\nMagical Strength = " + _item.GetMagicalStrengthStats();
                    break;
                case ItemType.Eat:
                    content += "\n\nStats :\nEat = " + _item.GetStaminaStats();
                    break;
                case ItemType.Heal:
                    content += "\n\nStats :\nHeal = " + _item.GetHealing();
                    break;
                default:
                    break;
            }
            TooltipSystem.Instance.Show(content, _item.name);
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
        _itemActionsSystem.OpenActionPanel(_item, _transform.position);
    }
}