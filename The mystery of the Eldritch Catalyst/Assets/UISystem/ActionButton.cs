using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public void ActionOne()
    {
        CharacterSelection.Instance.GetSelectedCharacter().ActionOne();
    }

    public void ActionTwo() 
    {
        CharacterSelection.Instance.GetSelectedCharacter().ActionTwo();
    }
}
