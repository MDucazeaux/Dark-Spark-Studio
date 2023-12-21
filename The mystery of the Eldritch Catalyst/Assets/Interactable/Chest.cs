using System.Collections;
using UnityEngine;

public class Chest : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;

    [SerializeField] private GameObject _breakParticles;

    [SerializeField] private Transform _dropPoint;

    [SerializeField] private string _name;

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


    private void OpenChest(bool breaking = false)
    {
        if (!breaking)
        {
            DropManager.Instance.DropItemsInChests(_dropPoint, _name);
        }
        else
        {
            DropManager.Instance.DropItemsToLootInChests(_dropPoint, _name);
        }
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.OpeningDoor, 1);
    }

    public override bool CanInteract()
    {
        return (!_bIsOpened && !_bIsLocked);
    }

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }

    public void Unlock()
    { _bIsLocked = false; }

    public override void BreakInteractable(bool alternate = false)
    {
        _bIsOpened = true;
        OpenChest(true);
        if (_breakParticles)
        {
            Instantiate(_breakParticles, transform.position, transform.rotation);
        }
        gameObject.SetActive(false);
    }

    public bool IsOpened { get { return _bIsOpened; } }
}
