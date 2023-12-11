using Unity.VisualScripting;
using UnityEngine;

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

    public bool IsSelected(int portraitID)
    {
        return (_select1 == portraitID || _select2 == portraitID);
    }
}
