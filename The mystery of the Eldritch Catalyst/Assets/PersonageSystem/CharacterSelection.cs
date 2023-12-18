using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance;

    public List<Character> _charactersList;
    private Dictionary<string, Character> _characters = new Dictionary<string, Character>();
    private List<string> _placement = new List<string>();
    private int _characterIndex;

    [SerializeField]
    private EquipmentSlot _armorSlot;
    
    [SerializeField]
    private EquipmentSlot _weaponSlot;

    [SerializeField]
    private CharacterPortraitInInventory _characterPortraitInInventory;

    private void Awake()
    {
        Instance = this;
          
        _placement.Add("Ruffian");
        _placement.Add("Thief");
        _placement.Add("Witch");
        _placement.Add("Alchemist");
    }

    private void Start()
    {
        for (int i = 0; i < _charactersList.Count; i++)
        {
            switch (_charactersList[i].GetName())
            {
                case "Ruffian": _characters.Add("Ruffian", _charactersList[i]); break;
                case "Thief": _characters.Add("Thief", _charactersList[i]); break;
                case "Witch": _characters.Add("Witch", _charactersList[i]); break;
                case "Alchemist": _characters.Add("Alchemist", _charactersList[i]); break;

                default: Debug.Log("Error Name"); break;
            }
        }
    }

    public void SelectCharacter(int new_character_index)
    {
        _characterIndex = new_character_index;
        _armorSlot.RefreshVisual();
        _weaponSlot.RefreshVisual();
        _characterPortraitInInventory.RefreshVisual();
    }

    public void SwitchCharacters(int character1, int character2)
    {
        string savecharacter1 = _placement[character1];
        _placement[character1] = _placement[character2];
        _placement[character2] = savecharacter1;
    }

    public void CharacterDeath(string name)
    {
        int characterPlacement = GetCharacterPlacement(name);

        switch (characterPlacement)
        {
            case 0:
                if (CharacterPlacementIsAlive(2))
                { SwitchCharacters(0, 2); }
                else if (CharacterPlacementIsAlive(3))
                { SwitchCharacters(0, 3);}
                break;
            case 1:
                if (CharacterPlacementIsAlive(2))
                { SwitchCharacters(1, 3); }
                else if (CharacterPlacementIsAlive(3))
                { SwitchCharacters(1, 2); }
                break;

            default: break;
        }
    }

    private int GetCharacterPlacement(string character)
    {
        for (int i = 0; i < _placement.Count;i++)
        {
            if (_placement[i] == character) 
                return i;
        }
        return -1;
    }

    private bool CharacterPlacementIsAlive(int character)
    {
        return !_characters[_placement[character]].IsDead;
    }

    public Dictionary<string, Character> Characters { get { return _characters; } }
    public List<string> CharactersPlacement { get { return _placement; } }

    public bool IsSelected(int characterIndexCheck)
    {
        return (characterIndexCheck == _characterIndex);
    }

    public Character GetSelectedCharacter()
    {
        return _characters[_placement[_characterIndex]];
    }

    public Character GetCharacterByName(string name)
    {
        foreach(Character character in _charactersList) 
        {
            if (character.GetName().Equals(name))
            {
                return character;
            }
        }
        return null;
    }

    public List<Character> CharactersList() { return _charactersList; }
}