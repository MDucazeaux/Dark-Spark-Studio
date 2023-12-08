using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarratifTest : MonoBehaviour
{
    private List<string> _list = new List<string>()
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

    [SerializeField]
    private TextMeshProUGUI _text;

    private int _index = 0;
    private bool _bCanSwitchText = true;

    private void Start()
    {
        _text.text = _list[_index];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _index = (_index + 1) % _list.Count;
            _text.text = _list[_index];
        }
    }

    public bool CanSwitchText { get { return _bCanSwitchText; } set { _bCanSwitchText = value; /*gameObject.SetActive(true);*/ } }
}
