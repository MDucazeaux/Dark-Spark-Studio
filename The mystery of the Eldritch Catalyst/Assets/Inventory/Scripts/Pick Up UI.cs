using System.Collections.Generic;
using UnityEngine;

public class PickUpUI : MonoBehaviour
{
    private Stack<ItemData> _pickedUpItems;

    public void PushPickedUpItem(ItemData item)
    {
        _pickedUpItems.Push(item);
    }

    public void PopPickedUpItem(ItemData item)
    {
        _pickedUpItems.Pop();
    }
}