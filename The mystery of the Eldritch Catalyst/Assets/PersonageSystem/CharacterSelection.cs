using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance;

    private Dictionary<string, Character> _characters = new Dictionary<string, Character>();
    private List<string> _placement = new List<string>();
    private int _characterIndex;

    [SerializeField]
    private EquipmentSlot _armorSlot;
    
    [SerializeField]
    private EquipmentSlot _weaponSlot;

    private void Awake()
    {
        Instance = this;
        _characters.Add("Ruffian", new Ruffian());
        _characters.Add("Thief", new Thief());
        _characters.Add("Witch", new Witch());
        _characters.Add("Alchemist", new Alchemist());
        _characters["Ruffian"].Awake();
        _characters["Thief"].Awake();
        _characters["Witch"].Awake();
        _characters["Alchemist"].Awake();

        _placement.Add("Ruffian");
        _placement.Add("Thief");
        _placement.Add("Witch");
        _placement.Add("Alchemist");
    }

    public void SelectCharacter(int new_character_index)
    {
        _characterIndex = new_character_index;
        _armorSlot.RefreshVisual();
        _weaponSlot.RefreshVisual();
    }

    public void SwitchCharacters(int character1, int character2)
    {
        string savecharacter1 = _placement[character1];
        _placement[character1] = _placement[character2];
        _placement[character2] = savecharacter1;
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
}
