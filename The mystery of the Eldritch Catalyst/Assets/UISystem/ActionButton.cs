using UnityEngine;

public class ActionButton : MonoBehaviour
{
    public static ActionButton Instance;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
    }

    public void ActionOne()
    {
        Character character = CharacterSelection.Instance.GetSelectedCharacter();

        if (character.GetLife() >= 0)
        {
            character.ActionOne();
        }
    }

    public void ActionTwo() 
    {
        Character character = CharacterSelection.Instance.GetSelectedCharacter();

        if (character.GetLife() >= 0)
        {
            character.ActionTwo();
        }
    }
}
