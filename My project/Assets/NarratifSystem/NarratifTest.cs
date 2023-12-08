using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NarratifTest : MonoBehaviour
{
    private List<string> _list = new List<string>()
    {
        "Dans un monde o� la magie et les monstres sont omnipr�sents, un homme myst�rieux cherchait � recruter de courageux aventuriers." +
        "\n\n\rSa qu�te : r�cup�rer un ancien et puissant art�fact situ� dans les ruines d�une ancienne civilisation : le catalyseur d�Eldritch.",

        "C�est dans une taverne douteuse qu�il fit la rencontre de quatre aventuriers :" +
        "\n\rMagnus Stormblade une brute, Lila Nightshade une voleuse," +
        "\n\rElara Moonfire une sorci�re m�diocre et Thaddeus Emberstone un vieil alchimiste." +
        "\n\n\rLes 4 aventuriers, au d�but r�ticents, accept�rent la mission quand l�homme myst�rieux leur promit argent et pouvoir."
    };

    [SerializeField]
    private TextMeshProUGUI _text;

    private int _index = 0;

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
}
