using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private SlotType _slotType;

    [SerializeField]
    private Image _itemIcon;

    [SerializeField]
    private ItemActionSystem itemActionsSystem;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (_slotType) 
        {
            case SlotType.Armor :
                if (CharacterSelection.Instance.GetSelectedCharacter().GetArmor() != null)
                {
                    TooltipSystem.Instance.Show(CharacterSelection.Instance.GetSelectedCharacter().GetArmor().GetDescription(),
                                        CharacterSelection.Instance.GetSelectedCharacter().GetArmor().name);
                }
                break;
            case SlotType.Weapon :
                if (CharacterSelection.Instance.GetSelectedCharacter().GetWeapon() != null)
                {
                    TooltipSystem.Instance.Show(CharacterSelection.Instance.GetSelectedCharacter().GetWeapon().GetDescription(),
                                            CharacterSelection.Instance.GetSelectedCharacter().GetWeapon().name);
                }
                break;
            default:
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipSystem.Instance.Hide();
    }

    public void ClickOnSlot()
    {
        switch (_slotType)
        {
            case SlotType.Armor:
                if (CharacterSelection.Instance.GetSelectedCharacter().GetArmor() != null)
                {
                    DesequipEquipment();
                }
                break;
            case SlotType.Weapon:
                if (CharacterSelection.Instance.GetSelectedCharacter().GetWeapon() != null)
                {
                    DesequipEquipment();
                }
                break;
            default:
                break;
        }
    }

    public void EquipEquipment(ItemData equipment)
    {
        switch (_slotType)
        {
            case SlotType.Armor:
                CharacterSelection.Instance.GetSelectedCharacter().SetArmor(equipment);
                break;
            case SlotType.Weapon:
                CharacterSelection.Instance.GetSelectedCharacter().SetWeapon(equipment);
                break;
            default:
                break;
        }
        _itemIcon.sprite = equipment.GetIcon();
        Inventory.Instance.RemoveItem(equipment);
        Inventory.Instance.RefreshContent();
    }

    public void DesequipEquipment()
    {
        if (!Inventory.Instance.InventoryIsFull())
        {
            switch (_slotType)
            {
                case SlotType.Armor:
                    if (CharacterSelection.Instance.GetSelectedCharacter().GetArmor() != null)
                    {
                        Inventory.Instance.AddItem(CharacterSelection.Instance.GetSelectedCharacter().GetArmor());
                        CharacterSelection.Instance.GetSelectedCharacter().SetArmor(null);
                    }
                    break;
                case SlotType.Weapon:
                    if (CharacterSelection.Instance.GetSelectedCharacter().GetWeapon() != null)
                    {
                        Inventory.Instance.AddItem(CharacterSelection.Instance.GetSelectedCharacter().GetWeapon());
                        CharacterSelection.Instance.GetSelectedCharacter().SetWeapon(null);
                    }
                    break;
                default:
                    break;
            }
            _itemIcon.sprite = Inventory.Instance.GetTransparentSlot();
            Inventory.Instance.RefreshContent();
        }
    }

    public void SwapEquipment(ItemData equipment)
    {
        Inventory.Instance.RemoveItem(equipment);
        switch (_slotType)
        {
            case SlotType.Armor:
                Inventory.Instance.AddItem(CharacterSelection.Instance.GetSelectedCharacter().GetArmor());
                CharacterSelection.Instance.GetSelectedCharacter().SetArmor(equipment);
                break;
            case SlotType.Weapon:
                Inventory.Instance.AddItem(CharacterSelection.Instance.GetSelectedCharacter().GetWeapon());
                CharacterSelection.Instance.GetSelectedCharacter().SetWeapon(equipment);
                break;
            default:
                break;
        }
        _itemIcon.sprite = equipment.GetIcon();
        Inventory.Instance.RefreshContent();
    }

    public ItemData GetItem()
    {
        switch (_slotType)
        {
            case SlotType.Armor:
                return CharacterSelection.Instance.GetSelectedCharacter().GetArmor();
            case SlotType.Weapon:
                return CharacterSelection.Instance.GetSelectedCharacter().GetWeapon();
            default:
                return null;
        }
    }

    public void RefreshVisual()
    {
        switch (_slotType)
        {
            case SlotType.Armor:
                _itemIcon.sprite = CharacterSelection.Instance.GetSelectedCharacter().GetArmor().GetIcon();
                break;
            case SlotType.Weapon:
                _itemIcon.sprite = CharacterSelection.Instance.GetSelectedCharacter().GetWeapon().GetIcon();
                break;
            default:
                break;
        }
    }

    public enum SlotType
    {
        Armor,
        Weapon,
    }
}