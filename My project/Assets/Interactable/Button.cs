using UnityEngine;

public class Button : Interactable
{
    private bool _bIsActivated = false;
    [SerializeField] private bool _bIsHidden = false;

    public override void Interaction()
    {
        if (!_bIsHidden)
        {
            if (!_bIsActivated)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        _bIsActivated = true;
    }

    public bool IsHidden { get { return _bIsHidden; } set { _bIsHidden = value; } }
}
