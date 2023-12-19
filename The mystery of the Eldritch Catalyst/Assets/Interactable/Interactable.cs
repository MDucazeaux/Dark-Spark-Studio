using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interaction();

    public abstract bool CanInteract();

    public abstract void BreakInteractable();
}
