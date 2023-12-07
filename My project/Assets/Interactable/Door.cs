using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;

    public override void Interaction()
    {
        if (!_bIsLocked)
        {
            if (!_bIsOpened)
            {
                Open();
            }
        }
    }

    private void Open()
    {
        _bIsOpened = true;
    }

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value;  } }
}
