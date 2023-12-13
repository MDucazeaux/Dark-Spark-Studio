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
    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private TextMeshProUGUI _character;
    [SerializeField] private Image _face;
    [SerializeField] private Image _background;

    private float _time = 0;
    private int _waitTime = 3;

    private bool _canPassText = true;
    private int _index = 0;

    private string _survivor = "survivor";

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
    
    private List<string> _goodEndOneTexts = new List<string>()
    {
        "Despite the fearsome power of their adversary, the adventurer emerged triumphant from this arduous battle. " +
        "Once he had recovered from his wounds, he decided to destroy the cursed artifact and seal the entrance to the dungeon forever, " +
        "ensuring that no other human being would be able to enter."
    };
    private List<string> _goodEndSeveralTexts = new List<string>()
    {
        "Despite the fearsome power of their adversary, the adventurers emerged triumphant from this arduous battle. " +
        "Once they had recovered from their wounds, they decided to destroy the cursed artifact and seal the entrance to the dungeon forever, " +
        "ensuring that no other human being would be able to enter."
    };

    private List<string> _badEndDungeonTexts = new List<string>()
    { "Despite their best efforts and unfailing tenacity, the adventurers were unable to overcome the dungeon’s."};
    private List<string> _badEndBossTexts = new List<string>()
    { "Despite their best efforts and unfailing tenacity, the adventurers were unable to overcome the mysterious power of their opponents."};
    
    [SerializeField] private List<Sprite> _faces = new List<Sprite>(); //warrior, thief, witch, alchimist, mysterious being 

    public enum NarrativePhase
    {
        Intro,

        BeforeBossFight,
        
        GoodEndOne,
        GoodEndSeveral,
        
        BadEndDungeon,
        BadEndBoss,
        
        None
    }

    public NarrativePhase _phase = NarrativePhase.Intro;

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
                case NarrativePhase.Intro:
                    if (_index == _introTexts.Count)
                    {
                        _canPassText = false;
                        StartCoroutine(DesableBackground());
                        //gamemanager launch game
                        Debug.Log("end intro");

                    }
                    else
                    {
                        _text.text = _introTexts[_index++];
                    }
                    break;

                case NarrativePhase.BeforeBossFight:
                    if (_index == _gameTexts.Count)
                    {
                        _canPassText = false;
                        DesableDialogue();
                        //gamemanager launch boss fight
                        Debug.Log("end boss fight");
                    }
                    else
                    {
                        ChangeCharacter();
                        SwitchFace();
                        _dialogue.text = _gameTexts[_index++];
                    }
                    break;

                case NarrativePhase.GoodEndOne:
                    if (_index == _goodEndOneTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end good end one");
                    }
                    else
                    {
                        _text.text = _goodEndOneTexts[_index++];
                    }
                    break;

                case NarrativePhase.GoodEndSeveral:
                    if (_index == _goodEndSeveralTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end good end several");
                    }
                    else
                    {
                        _text.text = _goodEndSeveralTexts[_index++];
                    }
                    break;

                case NarrativePhase.BadEndDungeon:
                    if (_index == _badEndDungeonTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end bad end dungeon");
                    }
                    else
                    {
                        _text.text = _badEndDungeonTexts[_index++];
                    }
                    break;

                case NarrativePhase.BadEndBoss:
                    if (_index == _badEndBossTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end bad end boss");
                    }
                    else
                    {
                        _text.text = _badEndBossTexts[_index++];
                    }
                    break;

                case NarrativePhase.None:
                    Debug.Log("None NarrativePhase");
                    break;

                default:
                    Debug.Log("Error NarrativePhase");
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NextNarratifPhase();
        }
    }

    public void ChangePhase(NarrativePhase NarrativePhase)
    {
        _phase = NarrativePhase;

        _canPassText = true;
        _index = 0;

        switch (_phase)
        {
            case NarrativePhase.Intro:
                EnableNarratif();

                _text.text = _introTexts[_index++];
                break;

            case NarrativePhase.BeforeBossFight:
                EnableDialogue();
                ChangeCharacter();
                SwitchFace();

                _dialogue.text = _gameTexts[_index++];
                break;

            case NarrativePhase.GoodEndOne:
                EnableNarratif();

                _text.text = _goodEndOneTexts[_index++];
                break;

            case NarrativePhase.GoodEndSeveral:
                EnableNarratif();

                _text.text = _goodEndSeveralTexts[_index++];
                break;

            case NarrativePhase.BadEndDungeon:
                EnableNarratif();

                _text.text = _badEndDungeonTexts[_index++];
                break;

            case NarrativePhase.BadEndBoss:
                EnableNarratif();

                _text.text = _badEndBossTexts[_index++];
                break;

            case NarrativePhase.None:
                Debug.Log("None NarrativePhase");
                break;

            default:
                Debug.Log("Error NarrativePhase");
                break;
        }
    }

    private void NextNarratifPhase()
    {
        var NarrativePhase = Enum.GetValues(typeof(NarrativePhase)).Cast<NarrativePhase>().SkipWhile(e => e != _phase).Skip(1).First();
        NarrativePhase = NarrativePhase == NarrativePhase.None ? NarrativePhase.Intro : NarrativePhase;
        ChangePhase(NarrativePhase);
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

        while (_time < _waitTime)
        {
            _background.color = Color.Lerp(fromBg, toBg, _time);
            _text.color = Color.Lerp(fromTxt, toTxt, _time);
            _time += Time.deltaTime;
            yield return null;
        }

        _text.enabled = false;
    }

    private void EnableDialogue()
    {
        _dialogue.enabled = true;
        _face.enabled = true;
        _character.enabled = true;
    }

    private void DesableDialogue()
    {
        _face.enabled = false;
        _dialogue.enabled = false;
        _character.enabled = false;
    }

    private void EnableNarratif()
    {
        _text.enabled = true;

        _background.color = Color.black; 
        _text.color = Color.white;
    }

    public void SetSurvivor(string survivor)
    { 
        _survivor = survivor;

        if (_survivor == "Magnus Stormblade" || _survivor == "Thaddeus Emberstone")
        {
            List<string> goodEndOneText = new List<string>()
            {
                "Despite the fearsome power of their adversary," + _survivor + " emerged triumphant from this arduous battle. " +
                "Once he had recovered from his wounds, he decided to destroy the cursed artifact and seal the entrance to the dungeon forever, " +
                "ensuring that no other human being would be able to enter."
            };

            _goodEndOneTexts = goodEndOneText;
        }
        else if (_survivor == "Lila Nightshade" || _survivor == "Elara Moonfire")
        {
            List<string> goodEndOneText = new List<string>()
            {
                "Despite the fearsome power of their adversary," + _survivor + " emerged triumphant from this arduous battle. " +
                "Once she had recovered from her wounds, she decided to destroy the cursed artifact and seal the entrance to the dungeon forever, " +
                "ensuring that no other human being would be able to enter."
            };

            _goodEndOneTexts = goodEndOneText;
        }
    }
}
