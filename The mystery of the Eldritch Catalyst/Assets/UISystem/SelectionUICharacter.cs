using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionUICharacter : MonoBehaviour
{
    public static SelectionUICharacter Instance;

    private CharacterSelection _characterSelection;

    public int _select1 = -1;
    public int _select2 = -1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _characterSelection = CharacterSelection.Instance;
    }

    public void SelectPortrait(int portraitID)
    {
        if (_select1 == -1)
        {
            if (!_characterSelection.IsSelected(portraitID))
            {
                _characterSelection.SelectCharacter(portraitID);
                return;
            }
            _select1 = portraitID;
            _characterSelection.SelectCharacter(_select1);
        }
        else
        {
            if (_select1 == portraitID)
            {
                UnselectAll();
                return;
            }
            _select2 = portraitID;
            if (_characterSelection.Characters[_characterSelection.CharactersPlacement[_select1]].IsDead 
                || _characterSelection.Characters[_characterSelection.CharactersPlacement[_select2]].IsDead)
            {
                UnselectAll();
                return;
            }
            _characterSelection.SwitchCharacters(_select1, _select2);
            _characterSelection.SelectCharacter(_select2);
            UnselectAll();
        }
        
    }

    public void UnselectAll()
    {
        _select1 = -1;
        _select2 = -1;
    }

    public bool IsSelectedPlacement(int portraitID)
    {
        return (_select1 == portraitID || _select2 == portraitID);
    }
}
