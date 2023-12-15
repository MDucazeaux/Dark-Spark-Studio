using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite1;
    [SerializeField] private Image _healthBarSprite2;
    [SerializeField] private Image _healthBarSprite3;
    [SerializeField] private Image _healthBarSprite4;

    [SerializeField] private TextMeshProUGUI _healthBarText1;
    [SerializeField] private TextMeshProUGUI _healthBarText2;
    [SerializeField] private TextMeshProUGUI _healthBarText3;
    [SerializeField] private TextMeshProUGUI _healthBarText4;

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
                    _healthBarSprite1.fillAmount = character.GetLife() / character.GetLifeMax();
                    _healthBarText1.text = character.GetLife() + "/" + character.GetLifeMax();
                    break;
                case 1:
                    _healthBarSprite2.fillAmount = character.GetLife() / character.GetLifeMax();
                    _healthBarText2.text = character.GetLife() + "/" + character.GetLifeMax();
                    break;
                case 2:
                    _healthBarSprite3.fillAmount = character.GetLife() / character.GetLifeMax();
                    _healthBarText3.text = character.GetLife() + "/" + character.GetLifeMax();
                    break;
                case 3:
                    _healthBarSprite4.fillAmount = character.GetLife() / character.GetLifeMax();
                    _healthBarText4.text = character.GetLife() + "/" + character.GetLifeMax();
                    break;
            }
            
        }
    }
}
