using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private List<Character> _characters = new List<Character>();
    private int _characterIndex;

    private void Awake()
    {
        _characters.Add(new Ruffian());
        _characters.Add(new Thief());
        _characters.Add(new Witch());
        _characters.Add(new Alchemist());
    }

    public void SelectCharacter(int new_character_index)
    {
        _characterIndex = new_character_index;
    }
}
