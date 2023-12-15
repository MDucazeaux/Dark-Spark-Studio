using TMPro;
using UnityEngine;

public class HealTestr : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _fromDropdown;
    [SerializeField] private TMP_Dropdown _toDropdown;
    public void OnHealing()
    {
        string from = _fromDropdown.options[_fromDropdown.value].text;
        string to = _toDropdown.options[_toDropdown.value].text;
        Debug.Log(CharacterSelection.Instance.Characters[to].GetLife());
        CharacterSelection.Instance.Characters[to].Heal(25, CharacterSelection.Instance.Characters[from].GetHealMultiplier());
        Debug.Log(CharacterSelection.Instance.Characters[to].GetLife());
    }
}
