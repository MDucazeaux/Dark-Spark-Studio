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
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.DullahanIdle);
        Character character = CharacterSelection.Instance.GetSelectedCharacter();
        switch (_slotType)
        {
            case SlotType.Armor:
                character.SetArmor(equipment);
                character.AddArmorMultiplier(equipment.GetArmorStats());
                break;
            case SlotType.Weapon:
                character.SetWeapon(equipment);
                character.AddStrenghtMultiplier(equipment.GetPhysicalStrengthStats());
                character.AddMagicalStrenghtMultiplier(equipment.GetMagicalStrengthStats());
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
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.DullahanIdle);
            Character character = CharacterSelection.Instance.GetSelectedCharacter();
            switch (_slotType)
            {
                case SlotType.Armor:
                    if (character.GetArmor() != null)
                    {
                        Inventory.Instance.AddItem(character.GetArmor());
                        character.ReduceArmorMultiplier(character.GetArmor().GetArmorStats());
                        character.SetArmor(null);
                    }
                    break;
                case SlotType.Weapon:
                    if (character.GetWeapon() != null)
                    {
                        Inventory.Instance.AddItem(character.GetWeapon());
                        character.ReduceStrenghtMultiplier(character.GetWeapon().GetPhysicalStrengthStats());
                        character.ReduceMagicalStrenghtMultiplier(character.GetWeapon().GetMagicalStrengthStats());
                        character.SetWeapon(null);
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
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.DullahanMoving);
        Inventory.Instance.RemoveItem(equipment);
        Character character = CharacterSelection.Instance.GetSelectedCharacter();
        switch (_slotType)
        {
            case SlotType.Armor:
                character.ReduceArmorMultiplier(character.GetArmor().GetArmorStats());
                Inventory.Instance.AddItem(character.GetArmor());

                character.SetArmor(equipment);
                character.AddArmorMultiplier(equipment.GetArmorStats());
                break;

            case SlotType.Weapon:
                character.ReduceStrenghtMultiplier(character.GetWeapon().GetPhysicalStrengthStats());
                character.ReduceMagicalStrenghtMultiplier(character.GetWeapon().GetMagicalStrengthStats());
                Inventory.Instance.AddItem(character.GetWeapon());

                character.SetWeapon(equipment);
                character.AddStrenghtMultiplier(equipment.GetPhysicalStrengthStats());
                character.AddMagicalStrenghtMultiplier(equipment.GetMagicalStrengthStats());
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