using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSoundScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.ButtonClick);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.ButtonHover);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
