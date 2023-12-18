using UnityEngine;

public class CharacterPortraitInInventory : MonoBehaviour
{
    [SerializeField]
    private GameObject _witchPortrait;

    [SerializeField]
    private GameObject _thiefPortrait;

    [SerializeField]
    private GameObject _ruffianPortrait;

    [SerializeField]
    private GameObject _alchemistPortrait;

    public void RefreshVisual()
    {
        switch (CharacterSelection.Instance.GetSelectedCharacter().GetName())
        {
            case "Alchemist":
                _alchemistPortrait.SetActive(true);
                _witchPortrait.SetActive(false);
                _thiefPortrait.SetActive(false);
                _ruffianPortrait.SetActive(false);
                break;
            case "Witch":
                _witchPortrait.SetActive(true);
                _alchemistPortrait.SetActive(false);
                _thiefPortrait.SetActive(false);
                _ruffianPortrait.SetActive(false);
                break;
            case "Thief":
                _thiefPortrait.SetActive(true);
                _alchemistPortrait.SetActive(false);
                _witchPortrait.SetActive(false);
                _ruffianPortrait.SetActive(false);
                break;
            case "Ruffian":
                _ruffianPortrait.SetActive(true);
                _alchemistPortrait.SetActive(false);
                _witchPortrait.SetActive(false);
                _thiefPortrait.SetActive(false);
                break;
            default:
                break;
        }
    }
}
