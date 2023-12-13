using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarratifManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _dialogue;
    [SerializeField] private TextMeshProUGUI _character;
    [SerializeField] private Image _face;
    [SerializeField] private Image _background;

    private float _time = 0;
    private int _waitTime = 3;

    private bool _canPassText = true;
    private int _index = 0;

    #region vf
    /*private List<string> _introTexts = new List<string>()
    {
        "Dans un monde où la magie et les monstres sont omniprésents, un homme mystérieux cherchait à recruter de courageux aventuriers." +
        "\n\n\rSa quête : récupérer un ancien et puissant artéfact situé dans les ruines d’une ancienne civilisation : le catalyseur d’Eldritch.",

        "C’est dans une taverne douteuse qu’il fit la rencontre de quatre aventuriers :" +
        "\n\rMagnus Stormblade une brute, Lila Nightshade une voleuse," +
        "\n\rElara Moonfire une sorcière médiocre et Thaddeus Emberstone un vieil alchimiste." +
        "\n\n\rLes 4 aventuriers, au début réticents, acceptèrent la mission quand l’homme mystérieux leur promit argent et pouvoir.",

        "En entrant dans le donjon, Thaddeus Emberstone sentit que l’air était lourd " +
        "et tous sentirent leurs forces faiblir."
    };
    private List<string> _gameTexts = new List<string>()
    {
        "Homme mystérieux :",
        "Bien joué aventuriers, vous avez réussi à atteindre la fin du donjon.",

        "Magnus Stormblade :",
        "Mais… qu’est-ce que tu fais ici ?",

        "Thaddeus Emberstone",
        "C’était un piège de tout évidence, n’est-ce pas ?",

        "Homme mystérieux :",
        "C’est exact.",

        "Elara Moonfire :",
        "Qu’est-ce que vous allez nous faire ?",

        "Homme mystérieux :",
        "Je vais vous voler toute votre énergie vitale. " +
        "C’est à ça que sert cet artefact, “le catalyseur d’Eldritch”. " +
        "Il absorbe l’énergie vitale des humains présents en ces lieux, il la transfère à son propriétaire… moi.",

        "Lila Nightshade :",
        "Mais pourquoi faites vous ça ?",

        "Homme mystérieux :",
        "Pour vivre éternellement, quelle question.",

        "Magnus Stormblade :",
        "Tu t'es servi de nous. Je vais te massacrer.",

        "Homme mystérieux :",
        "Vas-y viens tenter ta chance !"
    };
    private List<string> _goodEndTexts = new List<string>()
    {
        "Malgré la redoutable puissance de leur antagoniste, les intrépides aventuriers sortirent triomphants de ce combat ardu. " +
        "Une fois guéris de leurs blessures, ils décidèrent de détruire l'artefact maudit et de sceller l'entrée du donjon, " +
        "veillant ainsi à ce qu'aucun autre être humain ne puisse pénétrer en ces lieux mystérieux.\r\n"
    };
    private List<string> _badEndTexts = new List<string>()
    { "Malgré leurs efforts et leurs ténacités, les aventuriers ne parvinrent pas à surpasser la puissance de l’homme mystérieux."};*/
    #endregion

    #region ve
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
    #endregion

    [SerializeField] private List<Sprite> _faces = new List<Sprite>(); //warrior, thief, witch, alchimist, 

    public enum Phase
    {
        Intro, BeforeBossFight, GoodEnd, BadEnd, None
    }

    public Phase _phase = Phase.Intro;

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
                case Phase.Intro:
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

                case Phase.BeforeBossFight:
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

                case Phase.GoodEnd:
                    if (_index == _goodEndTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end good end");
                    }
                    else
                    {
                        _text.text = _goodEndTexts[_index++];
                    }
                    break;

                case Phase.BadEnd:
                    if (_index == _badEndTexts.Count)
                    {
                        _canPassText = false;

                        Debug.Log("end bad end");
                    }
                    else
                    {
                        _text.text = _badEndTexts[_index++];
                    }
                    break;

                case Phase.None:
                    Debug.Log("None Phase");
                    break;

                default:
                    Debug.Log("Error Phase");
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            NextNarratifPhase();
        }
    }

    public void NextNarratifPhase()
    {
        _phase = Enum.GetValues(typeof(Phase)).Cast<Phase>().SkipWhile(e => e != _phase).Skip(1).First();
        _phase = _phase == Phase.None ? Phase.Intro : _phase;

        _canPassText = true;
        _index = 0;

        switch (_phase)
        {
            case Phase.Intro:
                EnableNarratif();

                _text.text = _introTexts[_index++];
                break;

            case Phase.BeforeBossFight:
                EnableDialogue();
                ChangeCharacter();
                SwitchFace();

                _dialogue.text = _gameTexts[_index++];
                break;

            case Phase.GoodEnd:
                EnableNarratif();

                _text.text = _goodEndTexts[_index++];
                break;

            case Phase.BadEnd:
                EnableNarratif();

                _text.text = _badEndTexts[_index++];
                break;

            case Phase.None:
                Debug.Log("None Phase");
                break;

            default:
                Debug.Log("Error Phase");
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
}
