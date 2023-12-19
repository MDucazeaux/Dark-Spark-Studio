using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.ButtonClick, 0.3f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.ButtonHover, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }
}
