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

    [HideInInspector]
    private ItemData _itemToEquip;

    private bool _bEquipping;

    [SerializeField]
    private Transform dropPoint;

    //[SerializeField]
    //private Image consumableSlotImage;

    //private ItemData consumableEquiped;

    //[SerializeField]
    //private WeaponLibrary weaponLibrary;

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
            case ItemType.Equipment:
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
        //if (_itemCurrentlySelected.itemType == ItemType.Consumable)
        //{
        //    if (consumableEquiped != null)
        //    {
        //        ItemData consumableToDesequip = consumableEquiped;
        //        consumableEquiped = _itemCurrentlySelected;
        //        Inventory.Instance.RemoveItem(_itemCurrentlySelected);
        //        DesequipConsumable(consumableToDesequip);
        //        consumableSlotImage.sprite = consumableEquiped.icon;

        //    }
        //    else
        //    {
        //        consumableSlotImage.sprite = _itemCurrentlySelected.icon;
        //        consumableEquiped = _itemCurrentlySelected;
        //        Inventory.Instance.RemoveItem(_itemCurrentlySelected);
        //    }
        //    Inventory.Instance.RefreshContent();
        //}
        //else if (_itemCurrentlySelected.itemType == ItemType.Equipment)
        //{
        //    _itemToEquip = _itemCurrentlySelected;
        //    _bEquipping = true;
        //}
        print("equip");
        CloseActionPanel();
    }

    public void DropActionButton()
    {
        GameObject instantiatedItem = Instantiate(_itemCurrentlySelected.prefab);
        instantiatedItem.transform.position = dropPoint.position;
        Inventory.Instance.RemoveItem(_itemCurrentlySelected);
        Inventory.Instance.RefreshContent();
        CloseActionPanel();
    }

    //public void DesequipConsumable(ItemData consumable = null)
    //{
    //    if (consumable == null)
    //    {
    //        if (consumableEquiped == null)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            consumable = consumableEquiped;
    //        }
    //    }

    //    if (Inventory.Instance.InventoryIsFull())
    //    {
    //        return;
    //    }

    //    consumableSlotImage.sprite = Inventory.Instance.GetTransparentSlot();
    //    Inventory.Instance.AddItem(consumable);
    //    Inventory.Instance.RefreshContent();
    //}

    public GameObject GetActionPanel() {return _actionPanel;}
}