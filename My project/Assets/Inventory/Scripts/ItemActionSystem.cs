using UnityEngine;
using UnityEngine.UI;

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

    public void OpenActionPanel(ItemData item)
    {
        _itemCurrentlySelected = item;

        if (item == null)
        {
            _actionPanel.SetActive(false);
            return;
        }
        switch (item.itemType)
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
        if (_itemCurrentlySelected.itemType == ItemType.Armor) 
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
        else if(_itemCurrentlySelected.itemType == ItemType.Weapon)
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
        GameObject instantiatedItem = Instantiate(_itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = _dropPoint.position;
        Inventory.Instance.RemoveItem(_itemCurrentlySelected);
        Inventory.Instance.RefreshContent();
        CloseActionPanel();
    }

    public GameObject GetActionPanel() {return _actionPanel;}
}