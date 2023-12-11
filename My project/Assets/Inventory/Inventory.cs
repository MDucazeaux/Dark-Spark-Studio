using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<ItemData> _content = new List<ItemData>();

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
        RefreshContent();

    }

    public void CloseInventory()
    {
        _inventoryBackground.SetActive(false);
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

            currentSlot.setItemIcon(_content[i].icon);
        }
    }

    public bool InventoryIsFull()
    {
        return c_inventorySize == _content.Count;
    }

    public bool IsInInventory(ItemData item)
    {
        for (int i = 0; i < _content.Count; i++)
        {
            if (_content[i] == item)
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
}