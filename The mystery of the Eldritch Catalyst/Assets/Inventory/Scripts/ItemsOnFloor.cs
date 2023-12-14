using System.Collections.Generic;
using UnityEngine;

public class ItemsOnFloor : MonoBehaviour
{
    [SerializeField]
    private List<Item> _itemsOnFloor = new List<Item>();

    [SerializeField]
    private Transform _playerPosition;

    [SerializeField]
    private float cellSize = 10;

    public static ItemsOnFloor Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void AddItemOnTheFloor(Item item)
    {
        _itemsOnFloor.Add(item);
    }

    public void RemoveItemOnTheFloor(Item item)
    {
        _itemsOnFloor.Remove(item);
    }

    public List<Item> ItemsCloseToThePlayer()
    {
        List<Item> itemsCloseToThePlayer = new List<Item>();

        for (int i=0; i<_itemsOnFloor.Count; i++)
        {
            if(Mathf.Abs(_playerPosition.position.x - _itemsOnFloor[i].gameObject.transform.position.x) < cellSize/2 && 
               Mathf.Abs(_playerPosition.position.z - _itemsOnFloor[i].gameObject.transform.position.z) < cellSize/2)
            {
                itemsCloseToThePlayer.Add(_itemsOnFloor[i]);
            }
        }
        return itemsCloseToThePlayer;
    }
}
