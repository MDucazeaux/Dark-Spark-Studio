using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    public static ActionButton Instance;

    [SerializeField] private Image _buttonActionOne;
    [SerializeField] private Image _buttonActionTwo;

    [SerializeField] private Image CoolDownActionOne;
    [SerializeField] private Image CoolDownActionTwo;

    [SerializeField] private List<Sprite> _spriteActionsWitch;
    [SerializeField] private List<Sprite> _spriteActionsAlchemist;
    [SerializeField] private List<Sprite> _spriteActionsThief;
    [SerializeField] private List<Sprite> _spriteActionsRuffian;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
    }

    private void Update()
    {
        Character character = CharacterSelection.Instance.GetSelectedCharacter();

        CoolDownActionOne.fillAmount = character.CanActionOne ? 0 : 1 - character.TimeActionOne / character.CoolDownActionOne;
        CoolDownActionTwo.fillAmount = character.CanActionTwo ? 0 : 1 - character.TimeActionTwo / character.CoolDownActionTwo;
    }

    public void ChangeSpriteActions()
    {
        string character = CharacterSelection.Instance.GetSelectedCharacter().GetName();

        switch (character)
        {
            case "Witch":
                _buttonActionOne.sprite = _spriteActionsWitch[0];
                _buttonActionTwo.sprite = _spriteActionsWitch[1];
                break;

            case "Alchemist":
                _buttonActionOne.sprite = _spriteActionsAlchemist[0];
                _buttonActionTwo.sprite = _spriteActionsAlchemist[1];
                break;

            case "Thief":
                _buttonActionOne.sprite = _spriteActionsThief[0];
                _buttonActionTwo.sprite = _spriteActionsThief[1];
                break;

            case "Ruffian":
                _buttonActionOne.sprite = _spriteActionsRuffian[0];
                _buttonActionTwo.sprite = _spriteActionsRuffian[1];
                break;

            default:
                Debug.Log("Error wrong name");
                break;
        }
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
