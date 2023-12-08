using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarratifManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _dialogue;

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
    { "fvlbjs"};
    private List<string> _badEndTexts = new List<string>()
    { "skdjvlsihp"};

    public enum Phase
    {
        Intro, BeforeBossFight, GoodEnd, BadEnd
    }

    public Phase _phase = Phase.Intro;

    private bool _bInIntro = true;
    private bool _bInBeforeBossFight = false;
    private bool _bInGoodEnd = false;
    private bool _bInBadEnd = false;

    private void Start()
    {
        _name.enabled = false;

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
                        _bInIntro = false;
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
                        _bInBeforeBossFight = false;
                        _name.enabled = false;
                        _dialogue.enabled = false;
                        //gamemanager launch boss fight
                        Debug.Log("end boss fight");
                    }
                    else
                    {
                        _name.text = _gameTexts[_index++];
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
                _name.enabled = true; 
                _dialogue.enabled = true;
                _text.enabled = false;

                _name.text = _gameTexts[_index++]; 
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
}
