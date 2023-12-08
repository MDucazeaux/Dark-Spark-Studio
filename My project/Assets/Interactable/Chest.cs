using System.Collections;
using UnityEngine;

public class Chest : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;

    public override void Interaction()
    {
        if (!_bIsLocked && !_bIsOpened)
        {
            StartCoroutine(Open());
        }
    }

    private IEnumerator Open()
    {
        _bIsOpened = true;
        //chest animation here
        gameObject.SetActive(false);
        yield return null;
    }

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }
}
