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
    { "Malgré leurs efforts et leurs ténacités, les aventuriers ne parvinrent pas à surpasser la puissance de l’homme mystérieux."};

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
            case "Homme mystérieux :":
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
