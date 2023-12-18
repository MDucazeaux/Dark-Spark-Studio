using System.Collections;
using UnityEngine;

public class Chest : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;

    [SerializeField] private GameObject _breakParticles;

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
        OpenChest();
        //chest animation here
        gameObject.SetActive(false);
        yield return null;
    }


    private void OpenChest()
    {
        //put loot here
    }

    public override bool CanInteract()
    {
        return !_bIsOpened;
    }

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }

    public void Unlock()
    { _bIsLocked = false; }

    public override void BreakInteractable()
    {
        _bIsOpened = true;
        OpenChest();
        if (_breakParticles)
        {
            Instantiate(_breakParticles, transform.position, transform.rotation);
        }
        gameObject.SetActive(false);
    }
}
