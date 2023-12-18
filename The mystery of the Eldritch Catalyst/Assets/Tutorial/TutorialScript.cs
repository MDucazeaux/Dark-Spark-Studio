using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _panel;
    private bool _bisVisible = true;

    private int _tutorialId = 0;

    [SerializeField] private Door _openFirstDoor;
    [SerializeField] private Button _ButtonTo2;
    [SerializeField] private Door _DoorTo5;
    [SerializeField] private GameObject _ratTo7;
    [SerializeField] private Chest _chestTo8;

    [SerializeField] private Image _fadePanel;

    private float _savedHealth = -1;

    private bool _bisEnding = false;

    private void Awake()
    {
        UpdateText();
    }

    private void Update()
    {
        _text.gameObject.SetActive(_bisVisible);
        _panel.SetActive(_bisVisible);


        TutorialCheck();
        UpdateText();
    }

    private void TutorialCheck()
    {
        switch (_tutorialId)
        {
            case 0:
                if (_openFirstDoor.IsOpened)
                {
                    NextTutorial();
                    _bisVisible = false;
                }
                break;
            case 1:
                if (_ButtonTo2.IsActivated)
                {
                    NextTutorial();
                    _bisVisible = true;
                }
                break;
            case 3:
                if (CharacterSelection.Instance.GetSelectedCharacter().GetName() == "Thief")
                {
                    NextTutorial();
                    _bisVisible = true;
                    break;
                }
                if (_DoorTo5.IsOpened || !_DoorTo5.IsLocked)
                {
                    NextTutorial();
                }
                break;
            case 4:
                if (_DoorTo5.IsOpened || !_DoorTo5.IsLocked)
                {
                    NextTutorial();
                    _bisVisible = true;
                    break;
                }
                if (CharacterSelection.Instance.GetSelectedCharacter().GetName() != "Thief")
                {
                    PreviousTutorial();
                    _bisVisible = true;
                }
                break;
            case 5:
                if (_DoorTo5.IsOpened)
                {
                    NextTutorial();
                    _bisVisible = true;
                    break;
                }
                break;
            case 6:
                if (!_ratTo7)
                {
                    NextTutorial();
                    _bisVisible = true;
                    break;
                }
                break;
            case 7:
                if (_savedHealth == -1)
                {
                    _savedHealth = 0;
                    foreach (Character character in CharacterSelection.Instance.CharactersList())
                    {
                        _savedHealth += character.GetLife();
                    }
                }
                if (!_chestTo8 || _chestTo8.IsOpened)
                {
                    NextTutorial();
                }
                break;
            case 8:
                /*if (Inventory.Instance.IsInInventory("Medicinal Herb"))
                {
                    NextTutorial();
                }*/
                NextTutorial();
                break;
            case 9:
                float currentHealthTotal = 0;
                foreach (Character character in CharacterSelection.Instance.CharactersList())
                {
                    currentHealthTotal += character.GetLife();
                }
                if (currentHealthTotal > _savedHealth)
                {
                    NextTutorial();
                    break;
                }
                /*if (!Inventory.Instance.IsInInventory("Medicinal Herb"))
                {
                    PreviousTutorial();
                }*/
                break;
            case 10:
                if (!_bisEnding)
                {
                    _bisEnding = true;
                    StartCoroutine(GoBackToMenu());
                }
                break;
        }
        
    }

    private IEnumerator GoBackToMenu()
    {
        while (_fadePanel.color.a < 1)
        {
            _fadePanel.color = new Color(0, 0, 0, _fadePanel.color.a + 0.25f * Time.deltaTime);
            yield return null;
        }
        SceneManager.LoadSceneAsync("MainMenuScene");
    }

    public void NextTutorial()
    {
        _tutorialId++;
    }

    public void PreviousTutorial()
    {
        _tutorialId--;
    }

    private void UpdateText()
    {
        print(TutorialId);
        switch (_tutorialId)
        {
            case 0:
                _text.text = "Welcome to The Mystery of the Eldritch Catalyst\r\nTo begin your adventure open this door with [left click]";
                break;
            case 1:
                _text.text = "Hmm, it seems like we can't open this\nTry going back and check for a button, then interact with [left click]";
                break;
            case 2:
                _text.text = "The path has been cleared, let's continue your adventure";
                break;
            case 3:
                _text.text = "This door is locked, click on the Thief portrait to select her";
                break;
            case 4:
                _text.text = "Great ! Now that the Thief is Selected\nUse her special action with [é] to lockpick the door";
                break;
            case 5:
                _text.text = "Now you only have to open the door with [Left click]";
                break;
            case 6:
                _text.text = "Kill this rat now !\nPress [&] or [é] to use your actions";
                break;
            case 7:
                _text.text = "Okay that could have gotten worse\nLet's open that chest to find some loot";
                break;
            case 8:
                _text.text = "Nice we can heal ourselves with that !\nPick this item with [F]";
                break;
            case 9:
                _text.text = "Click on your bag to open the inventory\n then click on the item you just picked up and heal yourself";
                break;
            case 10:
                _text.text = "The tutorial is finished, now the real adventure can begin";
                break;
        }
    }

    public int TutorialId { get { return _tutorialId; } }
    public bool IsVisible { get { return _bisVisible; } set { _bisVisible = value; } }
}
