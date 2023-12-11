using UnityEngine;
using UnityEngine.UI;

public class CharacterPortraits : MonoBehaviour
{
    [SerializeField] private Sprite _spriteRuffian, _spriteWitch, _spriteThief, _spriteAlchemist;

    [SerializeField] private Image _portrait1, _portrait2, _portrait3, _portrait4;

    private CharacterSelection _characterSelection;
    private void Start()
    {
        _characterSelection = CharacterSelection.Instance;
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++) 
        { 
            string charactername = _characterSelection.CharactersPlacement[i];
            GetPortrait(i).sprite = GetSprite(charactername);
        }
    }

    private Image GetPortrait(int index)
    {
        switch (index)
        {
            case 0:
                return _portrait1;
            case 1:
                return _portrait2;
            case 2:
                return _portrait3;
            case 3:
                return _portrait4;
            default:
                Debug.Log("ERROR GETPORTRAIT IMAGE");
                break;
        }
        return null;
    }

    private Sprite GetSprite(string name)
    {
        switch (name)
        {
            case "Ruffian":
                return _spriteRuffian;
            case "Witch":
                return _spriteWitch;
            case "Thief":
                return _spriteThief;
            case "Alchemist":
                return _spriteAlchemist;
            default:
                Debug.Log("ERROR GETSPRITE PORTRAIT");
                break;
        }
        return null;
    }
}
