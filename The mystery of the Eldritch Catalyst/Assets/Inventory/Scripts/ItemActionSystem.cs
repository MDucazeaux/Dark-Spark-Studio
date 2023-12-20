using UnityEngine;

public class ItemActionSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _actionPanel;

    [SerializeField]
    private GameObject _healItemButton;

    [SerializeField]
    private GameObject _eatItemButton;

    [SerializeField]
    private GameObject _equipItemButton;

    [SerializeField]
    private GameObject _dropItemButton;

    [HideInInspector]
    private ItemData _itemCurrentlySelected;

    [SerializeField]
    private Transform _dropPoint;

    [SerializeField]
    private EquipmentSlot _armorSlot;

    [SerializeField]
    private EquipmentSlot _weaponSlot;
    
    [SerializeField] 
    private PlayerMovement _playerMovement;

    public static ItemActionSystem Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenActionPanel(ItemData item, Vector3 slotPosition)
    {
        _itemCurrentlySelected = item;
        _actionPanel.transform.position = slotPosition;

        if (item == null)
        {
            _actionPanel.SetActive(false);
            HealChoicePanel.Instance.CloseHealChoicePanel();
            return;
        }
        switch (item.GetItemType())
        {
            case ItemType.Armor:
                _healItemButton.SetActive(false);
                _eatItemButton.SetActive(false);
                _equipItemButton.SetActive(true);
                break;
            case ItemType.Weapon:
                _healItemButton.SetActive(false);
                _eatItemButton.SetActive(false);
                _equipItemButton.SetActive(true);
                break;
            case ItemType.Eat:
                _healItemButton.SetActive(false);
                _eatItemButton.SetActive(true);
                _equipItemButton.SetActive(false);
                break;
            case ItemType.Heal:
                _healItemButton.SetActive(true);
                _eatItemButton.SetActive(false);
                _equipItemButton.SetActive(false);
                break;
            case ItemType.Tools:
                _healItemButton.SetActive(false);
                _eatItemButton.SetActive(false);
                _equipItemButton.SetActive(false);
                break;
            default: 
                break;
        }
        _dropItemButton.SetActive(true);
        _actionPanel.SetActive(true);
    }

    public void CloseActionPanel()
    {
        _actionPanel.SetActive(false);
        _itemCurrentlySelected = null;
        HealChoicePanel.Instance.CloseHealChoicePanel();
    }

    public void EatActionButton()
    {
        if (!CharacterSelection.Instance.GetSelectedCharacter().IsDead && !CharacterSelection.Instance.GetSelectedCharacter().bIsMaxStamina())
        {
            CharacterSelection.Instance.GetSelectedCharacter().RecoverStamina(_itemCurrentlySelected.GetStaminaStats());
            Inventory.Instance.RemoveItem(_itemCurrentlySelected);
            Inventory.Instance.RefreshContent();
            CloseActionPanel();
        }
    }

    public void HealActionButton()
    {
        if (!CharacterSelection.Instance.GetSelectedCharacter().IsDead && !CharacterSelection.Instance.GetSelectedCharacter().bIsMaxLife())
        {
            HealChoicePanel.Instance.OpenHealChoicePanel();
        }
    }


    public void EquipActionButton()
    {
        if (_itemCurrentlySelected.GetItemType() == ItemType.Armor) 
        {
            if(_armorSlot.GetItem() == null)
            {
                _armorSlot.EquipEquipment(_itemCurrentlySelected);
            }
            else
            {
                _armorSlot.SwapEquipment(_itemCurrentlySelected);
            }
        }
        else if(_itemCurrentlySelected.GetItemType() == ItemType.Weapon)
        {
            if (_weaponSlot.GetItem() == null)
            {
                _weaponSlot.EquipEquipment(_itemCurrentlySelected);
            }
            else
            {
                _weaponSlot.SwapEquipment(_itemCurrentlySelected);
            }
        }
        CloseActionPanel();
    }

    public void DropActionButton()
    {
        if (!_playerMovement.IsMoving)
        {
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.PickupItem, 4);
            GameObject instantiatedItem = Instantiate(_itemCurrentlySelected.GetPrefab());
            instantiatedItem.transform.position = _dropPoint.position;
            Inventory.Instance.RemoveItem(_itemCurrentlySelected);
            Inventory.Instance.RefreshContent();
            CloseActionPanel();
        }
    }

    public GameObject GetActionPanel() {return _actionPanel;}
    public ItemData GetItemCurrentlySelected() {return _itemCurrentlySelected;}
}