using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarratifManager : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private TextMeshProUGUI _dialogue;
    private Image _face;

    private int _index = 0;

    private List<string> _introTexts = new List<string>()
    {
        "Dans un monde o� la magie et les monstres sont omnipr�sents, un homme myst�rieux cherchait � recruter de courageux aventuriers." +
        "\n\n\rSa qu�te : r�cup�rer un ancien et puissant art�fact situ� dans les ruines d�une ancienne civilisation : le catalyseur d�Eldritch.",

        "C�est dans une taverne douteuse qu�il fit la rencontre de quatre aventuriers :" +
        "\n\rMagnus Stormblade une brute, Lila Nightshade une voleuse," +
        "\n\rElara Moonfire une sorci�re m�diocre et Thaddeus Emberstone un vieil alchimiste." +
        "\n\n\rLes 4 aventuriers, au d�but r�ticents, accept�rent la mission quand l�homme myst�rieux leur promit argent et pouvoir.",

        "En entrant dans le donjon, Thaddeus Emberstone sentit que l�air �tait lourd " +
        "et tous sentirent leurs forces faiblir."
    };
    private List<string> _gameTexts = new List<string>()
    {
        "Homme myst�rieux :",
        "Bien jou� aventuriers, vous avez r�ussi � atteindre la fin du donjon.",

        "Magnus Stormblade :",
        "Mais� qu�est-ce que tu fais ici ?",

        "Thaddeus Emberstone",
        "C��tait un pi�ge de tout �vidence, n�est-ce pas ?",

        "Homme myst�rieux :",
        "C�est exact.",

        "Elara Moonfire :",
        "Qu�est-ce que vous allez nous faire ?",

        "Homme myst�rieux :",
        "Je vais vous voler toute votre �nergie vitale. " +
        "C�est � �a que sert cet artefact, �le catalyseur d�Eldritch�. " +
        "Il absorbe l��nergie vitale des humains pr�sents en ces lieux, il la transf�re � son propri�taire� moi.",

        "Lila Nightshade :",
        "Mais pourquoi faites vous �a ?",

        "Homme myst�rieux :",
        "Pour vivre �ternellement, quelle question.",

        "Magnus Stormblade :",
        "Tu t'es servi de nous. Je vais te massacrer.",

        "Homme myst�rieux :",
        "Vas-y viens tenter ta chance !"
    };
    private List<string> _goodEndTexts = new List<string>()
    {
        "Malgr� la redoutable puissance de leur antagoniste, les intr�pides aventuriers sortirent triomphants de ce combat ardu. " +
        "Une fois gu�ris de leurs blessures, ils d�cid�rent de d�truire l'artefact maudit et de sceller l'entr�e du donjon, " +
        "veillant ainsi � ce qu'aucun autre �tre humain ne puisse p�n�trer en ces lieux myst�rieux.\r\n"
    };
    private List<string> _badEndTexts = new List<string>()
    { "Malgr� leurs efforts et leurs t�nacit�s, les aventuriers ne parvinrent pas � surpasser la puissance de l�homme myst�rieux."};

    [SerializeField] private List<Sprite> _faces = new List<Sprite>(); //warrior, thief, witch, alchimist, 

    public enum Phase
    {
        Intro, BeforeBossFight, GoodEnd, BadEnd
    }

    public Phase _phase = Phase.Intro;

    private void Awake()
    {
        Transform[] children = GetComponentsInChildren<Transform>(true);

        _text = children[0].GetComponent<TextMeshProUGUI>();
        _dialogue = children[1].GetComponent<TextMeshProUGUI>();
        _face = children[2].GetComponent<Image>();
    }

    private void Start()
    {
        _text.text = _introTexts[_index++];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (_phase)
            {
                case Phase.Intro:
                    if (_index == _introTexts.Count)
                    {
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
                        _dialogue.enabled = false;
                        _face.enabled = false;
                        //gamemanager launch boss fight
                        Debug.Log("end boss fight");
                    }
                    else
                    {
                        SwitchFace();
                        _dialogue.text = _gameTexts[_index++];
                    }
                    break;

                case Phase.GoodEnd:
                    if (_index == _goodEndTexts.Count)
                    {

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

                        Debug.Log("end bad end");
                    }
                    else
                    {
                        _text.text = _badEndTexts[_index++];
                    }
                    break;

                default:
                    Debug.Log("Error Phase");
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangePhase(Phase.BeforeBossFight);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangePhase(Phase.GoodEnd);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangePhase(Phase.BadEnd);
        }
    }

    public void ChangePhase(Phase phase)
    {
        _phase = phase;
        _index = 0;

        switch (_phase)
        {
            case Phase.BeforeBossFight:
                _dialogue.enabled = true;
                _face.enabled = true;

                _text.enabled = false;
                SwitchFace();
                _dialogue.text = _gameTexts[_index++];
                break;

            case Phase.GoodEnd:
                _text.enabled = true;
                _text.text = _goodEndTexts[_index++];
                break;

            case Phase.BadEnd:
                _text.enabled = true;
                _text.text = _badEndTexts[_index++];
                break;

            default:
                Debug.Log("Error Phase");
                break;
        }
    }

    private void SwitchFace()
    {
        switch (_gameTexts[_index++])
        {
            case "Homme myst�rieux :":
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

            case "Thaddeus Emberstone":
                _face.sprite = _faces[3];
                break;

            default:
                Debug.Log("Error wrong name");
                break;
        }
    }
}
