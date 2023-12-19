using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;

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
                    ItemData armor = CharacterSelection.Instance.GetSelectedCharacter().GetArmor();
                    string content = armor.GetDescription();
                    content += "\n\nStats :\nArmor = " + armor.GetArmorStats();
                    TooltipSystem.Instance.Show(content, armor.name);
                }
                break;
            case SlotType.Weapon :
                if (CharacterSelection.Instance.GetSelectedCharacter().GetWeapon() != null)
                {
                    ItemData weapon = CharacterSelection.Instance.GetSelectedCharacter().GetWeapon();
                    string content = weapon.GetDescription();
                    content += "\n\nStats :\nPhysical Strength = " + weapon.GetPhysicalStrengthStats() + "\nMagical Strength = " + weapon.GetMagicalStrengthStats();
                    TooltipSystem.Instance.Show(content, weapon.name);
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
                if (CharacterSelection.Instance.GetSelectedCharacter().GetArmor() != null)
                {
                    _itemIcon.sprite = CharacterSelection.Instance.GetSelectedCharacter().GetArmor().GetIcon();
                }
                else
                {
                    _itemIcon.sprite = Inventory.Instance.GetTransparentSlot();
                }
                break;
            case SlotType.Weapon:
                if (CharacterSelection.Instance.GetSelectedCharacter().GetWeapon() != null)
                {
                    _itemIcon.sprite = CharacterSelection.Instance.GetSelectedCharacter().GetWeapon().GetIcon();
                }
                else
                {
                    _itemIcon.sprite = Inventory.Instance.GetTransparentSlot();
                }
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