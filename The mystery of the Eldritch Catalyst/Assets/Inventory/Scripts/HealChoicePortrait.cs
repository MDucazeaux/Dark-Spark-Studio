using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HealChoicePortrait : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] 
    private Image _hover;

    [SerializeField]
    private string _name;

    private void Awake()
    {
        _hover.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CharacterSelection.Instance.GetCharacterByName(_name).Heal(ItemActionSystem.Instance.GetItemCurrentlySelected().GetHealing(), CharacterSelection.Instance.GetSelectedCharacter().GetHealMultiplier());
        Inventory.Instance.RemoveItem(ItemActionSystem.Instance.GetItemCurrentlySelected());
        Inventory.Instance.RefreshContent();
        HealChoicePanel.Instance.CloseHealChoicePanel();
        ItemActionSystem.Instance.CloseActionPanel();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _hover.gameObject.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _hover.gameObject.SetActive(false);
    }
}