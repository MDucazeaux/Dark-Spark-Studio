using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarratifManager : MonoBehaviour
{
    public static NarratifManager Instance;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _infoContiueNarratif;
    [SerializeField] private TextMeshProUGUI _infoContiueDialogue;
    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private TextMeshProUGUI _character;
    [SerializeField] private TextMeshProUGUI _feedbackText;
    [SerializeField] private Image _face;
    [SerializeField] private Image _background;

    private float _time = 0;
    private int _waitTime = 2;
    private int _speed = 1;

    private float _feedbackTime = 0;
    private float _feedbackWait = 3;
    private float _feedbackWaitFade = 2;
    private Coroutine _fadeFeedBack;

    private bool _canPassText = true;
    private int _index = 0;

    private List<string> _introTexts = new List<string>()
    {
        "In a world where magic and fantastic creatures are omnipresent, a mysterious being with a frail, weather-beaten physique was striving to rally intrepid adventurers to his cause. " +
        "\n\n\rHis quest: to find an ancient and powerful artifact, the mysterious Eldritch Catalyst, hidden among the remains of an ancient civilization now extinct.",

        "It was in a tavern with a suspicious aura that he crossed paths with four adventurers: " +
        "\n\rMagnus Stormblade, a brute force; Lila Nightshade, a greedy thief; " +
        "\n\rElara Moonfire, a witch with modest powers; and Thaddeus Emberstone, an aging alchemist. " +
        "\n\n\rThe four adventurers, initially hesitant, gave in to the mysterious being's proposal when he offered the promise of money and power.",

        "As Thaddeus Emberstone entered the dungeon, he felt an oppressive heaviness permeate the atmosphere, draining the energy from every member of the group."
    };
    private List<string> _gameTexts = new List<string>()
    {
        "Mysterious Being :",
        "Well done, adventurers, you have reached the end of the dungeon.",

        "Magnus Stormblade :",
        "But... what are you doing here ?",

        "Thaddeus Emberstone :",
        "It was obviously a trap, wasn't it ?",

        "Mysterious Being :",
        "That’s right.",

        "Elara Moonfire :",
        "What do you plan to make us endure ?",

        "Mysterious Being :",
        "I'm going to steal all your life energy. ",

        "Mysterious Being :",
        "Behold this magnificent artifact, the Eldritch Catalyst; " +
        "it absorbs the life energy of the humans present in this place and transfers it to its owner... me.",

        "Lila Nightshade :",
        "But why are you doing this ?",

        "Mysterious Being :",
        "For eternal life, what a question.",

        "Magnus Stormblade :",
        "You used us. I'm going to massacre you.",

        "Mysterious Being :",
        "Go ahead, come and try your luck !"
    };
    private List<string> _goodEndTexts = new List<string>()
    {
        "Despite the formidable power of their adversary, the adventurers emerged triumphant from this arduous battle. " +
        "Once they had recovered from their wounds, they decided to destroy the cursed artifact and seal the entrance to the dungeon forever, " +
        "ensuring that no other human being would be able to enter."
    };
    private List<string> _badEndTexts = new List<string>()
    { "Despite their best efforts and unfailing tenacity, the adventurers were unable to overcome the mysterious power of their opponents."};

    [SerializeField] private List<Sprite> _faces = new List<Sprite>(); //warrior, thief, witch, alchimist, 

    public GameManager.NaratifPhase _phase = GameManager.NaratifPhase.Intro;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _text.text = _introTexts[_index++];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _canPassText)
        {
            switch (_phase)
            {
                case GameManager.NaratifPhase.Intro:
                    if (_index == _introTexts.Count)
                    {
                        _canPassText = false;
                        StartCoroutine(DesableBackground());
                        GameManager.Instance.LaunchGame();

                    }
                    else
                    {
                        _text.text = _introTexts[_index++];
                    }
                    break;

                case GameManager.NaratifPhase.BeforeBossFight:
                    if (_index == _gameTexts.Count)
                    {
                        _canPassText = false;
                        DesableDialogue();
                        GameManager.Instance.LaunchBossFight();
                    }
                    else
                    {
                        ChangeCharacter();
                        SwitchFace();
                        _dialogue.text = _gameTexts[_index++];
                    }
                    break;

                case GameManager.NaratifPhase.GoodEnd:
                    if (_index == _goodEndTexts.Count)
                    {
                        _canPassText = false;
                    }
                    else
                    {
                        _text.text = _goodEndTexts[_index++];
                    }
                    break;

                case GameManager.NaratifPhase.BadEnd:
                    if (_index == _badEndTexts.Count)
                    {
                        _canPassText = false;
                    }
                    else
                    {
                        _text.text = _badEndTexts[_index++];
                    }
                    break;

                default:
                    Debug.Log("Error GameManager.NaratifPhase");
                    break;
            }
        }

        if (Input.GetKey(KeyCode.N) && Input.GetKey(KeyCode.P))
        {
            NextNarratifPhase();
        }
    }

    public void NextNarratifPhase()
    {
        _phase = Enum.GetValues(typeof(GameManager.NaratifPhase)).Cast<GameManager.NaratifPhase>().SkipWhile(e => e != _phase).Skip(1).First();
        _phase = _phase == GameManager.NaratifPhase.None ? GameManager.NaratifPhase.Intro : _phase;

        ChangePhase(_phase);
    }

    public void ChangePhase(GameManager.NaratifPhase phase)
    {
        _phase = phase;
        _canPassText = true;
        _index = 0;

        switch (_phase)
        {
            case GameManager.NaratifPhase.BeforeBossFight:
                EnableDialogue();
                ChangeCharacter();
                SwitchFace();
                _dialogue.text = _gameTexts[_index++];
                break;

            case GameManager.NaratifPhase.GoodEnd:
                EnableNarratif();

                _text.text = _goodEndTexts[_index++];
                break;

            case GameManager.NaratifPhase.BadEnd:
                EnableNarratif();

                _text.text = _badEndTexts[_index++];
                break;

            default:
                Debug.Log("Error GameManager.NaratifPhase");
                break;
        }
    }

    private void ChangeCharacter()
    {
        _character.text = _gameTexts[_index++];
    }

    private void SwitchFace()
    {
        switch (_character.text)
        {
            case "Mysterious Being :":
                _face.sprite = _faces[4];
                break;

            case "Magnus Stormblade :":
                _face.sprite = _faces[0];
                break;

            case "Lila Nightshade :":
                _face.sprite = _faces[1];
                break;

            case "Elara Moonfire :":
                _face.sprite = _faces[2];
                break;

            case "Thaddeus Emberstone :":
                _face.sprite = _faces[3];
                break;

            default:
                Debug.Log("Error wrong name");
                break;
        }
    }

    private IEnumerator DesableBackground()
    {
        Color fromBg = Color.black;
        Color toBg = Color.clear;

        Color fromTxt = Color.white;
        Color toTxt = Color.white - Color.black;

        _time = 0;

        while (_time < 2)
        {
            _background.color = Color.Lerp(fromBg, toBg, _time);
            _text.color = Color.Lerp(fromTxt, toTxt, _time);
            _infoContiueNarratif.color = Color.Lerp(fromTxt, toTxt, _time);
            _time += Time.deltaTime;
            yield return null;
        }

        _background.raycastTarget = false;
        _text.enabled = false;
    }

    private void EnableDialogue()
    {
        _dialogue.enabled = true;
        _infoContiueDialogue.enabled = true;
        _face.enabled = true;
        _character.enabled = true;
    }

    private void DesableDialogue()
    {
        _face.enabled = false;
        _dialogue.enabled = false;
        _infoContiueDialogue.enabled = false;
        _character.enabled = false;
    }

    private void EnableNarratif()
    {
        _text.enabled = true;
        _background.raycastTarget = true;
        _background.color = Color.black;
        _text.color = Color.white;
        _infoContiueNarratif.color = Color.white;
    }

    public void FeedBackCharacterDie(string name)
    {
        _feedbackText.enabled = true;
        _feedbackText.color = Color.white;

        _feedbackText.text = name + " is dead.";
        _feedbackTime = Time.time + _feedbackWait;

        if (_fadeFeedBack != null)
            StopCoroutine(_fadeFeedBack);

        _fadeFeedBack = StartCoroutine(FadeFeedBack());
    }

    public void FeedBackKeyUse()
    {
        _feedbackText.enabled = true;
        _feedbackText.color = Color.white;

        _feedbackText.text = "You used the key.";
        _feedbackTime = Time.time + _feedbackWait;

        if (_fadeFeedBack != null)
            StopCoroutine(_fadeFeedBack);

        _fadeFeedBack = StartCoroutine(FadeFeedBack());
    }

    public void FeedBackLockpickUse()
    {
        _feedbackText.enabled = true;
        _feedbackText.color = Color.white;

        _feedbackText.text = "You used the lockpick.";
        _feedbackTime = Time.time + _feedbackWait;

        if (_fadeFeedBack != null)
            StopCoroutine(_fadeFeedBack);

        _fadeFeedBack = StartCoroutine(FadeFeedBack());
    }

    public void FeedBackNoKey()
    {
        _feedbackText.enabled = true;
        _feedbackText.color = Color.white;

        _feedbackText.text = "je n'ai pas de clé pour l'ouvrir mais ça a l'air fragile";
        _feedbackTime = Time.time + _feedbackWait;

        if (_fadeFeedBack != null)
            StopCoroutine(_fadeFeedBack);

        _fadeFeedBack = StartCoroutine(FadeFeedBack());
    }

    public void FeedBackNoLockpick()
    {
        _feedbackText.enabled = true;
        _feedbackText.color = Color.white;

        _feedbackText.text = "je n'ai pas de crochet pour l'ouvrir mais ça a l'air fragile";
        _feedbackTime = Time.time + _feedbackWait;

        if (_fadeFeedBack != null)
            StopCoroutine(_fadeFeedBack);

        _fadeFeedBack = StartCoroutine(FadeFeedBack());
    }

    private IEnumerator FadeFeedBack()
    {
        yield return new WaitWhile(() => Time.time < _feedbackTime);

        Color fromTxt = Color.white;
        Color toTxt = Color.white - Color.black;
        float time = 0;

        while (time < _feedbackTime)
        {
            _feedbackText.color = Color.Lerp(fromTxt, toTxt, time);
            time += Time.deltaTime;
            yield return null;
        }

        _feedbackText.enabled = false;
    }
}