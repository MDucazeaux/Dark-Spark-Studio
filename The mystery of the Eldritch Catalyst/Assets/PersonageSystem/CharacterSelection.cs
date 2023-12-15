using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public static CharacterSelection Instance;

    [SerializeField] private List<Character> _charactersList;
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
