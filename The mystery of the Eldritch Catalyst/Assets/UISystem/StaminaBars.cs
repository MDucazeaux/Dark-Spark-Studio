using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBars : MonoBehaviour
{
    [SerializeField] private Image _staminaBarSprite1;
    [SerializeField] private Image _staminaBarSprite2;
    [SerializeField] private Image _staminaBarSprite3;
    [SerializeField] private Image _staminaBarSprite4;

    [SerializeField] private TextMeshProUGUI _staminaBarText1;
    [SerializeField] private TextMeshProUGUI _staminaBarText2;
    [SerializeField] private TextMeshProUGUI _staminaBarText3;
    [SerializeField] private TextMeshProUGUI _staminaBarText4;

    private CharacterSelection _characterSelection;

    private void Start()
    {
        _characterSelection = CharacterSelection.Instance;
    }
    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            Character character = _characterSelection.Characters[_characterSelection.CharactersPlacement[i]];
            switch (i)
            {
                case 0:
                    _staminaBarSprite1.fillAmount = character.GetStamina() / character.GetStaminaMax;
                    _staminaBarText1.text = character.GetStamina() + "/" + character.GetStaminaMax;
                    break;
                case 1:
                    _staminaBarSprite2.fillAmount = character.GetStamina() / character.GetStaminaMax;
                    _staminaBarText2.text = character.GetStamina() + "/" + character.GetStaminaMax;
                    break;
                case 2:
                    _staminaBarSprite3.fillAmount = character.GetStamina() / character.GetStaminaMax;
                    _staminaBarText3.text = character.GetStamina() + "/" + character.GetStaminaMax;
                    break;
                case 3:
                    _staminaBarSprite4.fillAmount = character.GetStamina() / character.GetStaminaMax;
                    _staminaBarText4.text = character.GetStamina() + "/" + character.GetStaminaMax;
                    break;
            }
            
        }
    }
}
