using UnityEngine;

public class ItemActionSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _actionPanel;

    [SerializeField]
    private GameObject _useItemButton;

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

    public void OpenActionPanel(ItemData item, Vector3 slotPosition)
    {
        _itemCurrentlySelected = item;
        _actionPanel.transform.position = slotPosition;

        if (item == null)
        {
            _actionPanel.SetActive(false);
            return;
        }
        switch (item.GetItemType())
        {
            case ItemType.Armor:
                _useItemButton.SetActive(false);
                _equipItemButton.SetActive(true);
                _dropItemButton.SetActive(true);
                _actionPanel.SetActive(true);
                break;
            case ItemType.Weapon:
                _useItemButton.SetActive(false);
                _equipItemButton.SetActive(true);
                _dropItemButton.SetActive(true);
                _actionPanel.SetActive(true);
                break;
            case ItemType.Consumable:
                _useItemButton.SetActive(true);
                _equipItemButton.SetActive(false);
                _dropItemButton.SetActive(true);
                _actionPanel.SetActive(true);
                break;
        }
    }

    public void CloseActionPanel()
    {
        _actionPanel.SetActive(false);
        _itemCurrentlySelected = null;
    }

    public void UseActionButton()
    {
        Inventory.Instance.RemoveItem(_itemCurrentlySelected);
        Inventory.Instance.RefreshContent();
        CloseActionPanel();
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
            GameObject instantiatedItem = Instantiate(_itemCurrentlySelected.GetPrefab());
            instantiatedItem.transform.position = _dropPoint.position;
            Inventory.Instance.RemoveItem(_itemCurrentlySelected);
            Inventory.Instance.RefreshContent();
            CloseActionPanel();
        }
    }

    public GameObject GetActionPanel() {return _actionPanel;}
}