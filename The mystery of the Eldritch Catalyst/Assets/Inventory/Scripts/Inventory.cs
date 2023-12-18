using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _content = new List<ItemData>();

    [SerializeField]
    private ItemActionSystem _itemActionSystem;

    [SerializeField]
    private GameObject _inventoryBackground;

    [SerializeField]
    private Transform _inventorySlotsParent;

    [SerializeField]
    private Sprite _transparentSlot;

    private const int c_inventorySize = 20;

    public static Inventory Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        CloseInventory();
        RefreshContent();
    }

    private void Update()
    {
        RefreshContent();
    }

    public void AddItem(ItemData item)
    {
        _content.Add(item);
        RefreshContent();
    }

    public void RemoveItem(ItemData item)
    {
        _content.Remove(item);
        RefreshContent();
    }

    public void OpenInventory()
    {
        _inventoryBackground.SetActive(true);
        _itemActionSystem.GetActionPanel().SetActive(false);
        RefreshContent();

    }

    public void CloseInventory()
    {
        _inventoryBackground.SetActive(false);
        _itemActionSystem.GetActionPanel().SetActive(false);
    }

    public void SetActive() 
    {
        if (!_inventoryBackground.activeSelf) 
        {
            OpenInventory();
        }
        else
        {
            CloseInventory();
        }
    }

    public void RefreshContent()
    {
        for (int i = 0; i < _inventorySlotsParent.childCount; i++)
        {
            Slot currentSlot = _inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.setItem(null);
            currentSlot.setItemIcon(_transparentSlot);
        }

        for (int i = 0; i < _content.Count; i++)
        {

            Slot currentSlot = _inventorySlotsParent.GetChild(i).GetComponent<Slot>();
            currentSlot.setItem(_content[i]);

            currentSlot.setItemIcon(_content[i].GetIcon());
        }
    }

    public bool InventoryIsFull()
    {
        return c_inventorySize == _content.Count;
    }

    public bool IsInInventory(string item)
    {
        for (int i = 0; i < _content.Count; i++)
        {
            if (_content[i].GetName() == item)
            {
                return true;
            }
        }
        return false;
    }


    public List<ItemData> GetContent()
    {
        return _content;
    }

    public Sprite GetTransparentSlot() { return _transparentSlot; }

    public void RemoveItemByName(string itemName)
    {
        foreach (var item in _content)
        {
            if (item.GetName().Equals(itemName))
            {
                _content.Remove(item);
                RefreshContent();
            }
        }
    }
}