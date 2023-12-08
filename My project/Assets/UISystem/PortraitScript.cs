using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PortraitScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private bool _mouseOnPortrait = false;
    private bool _isClicked = false;

    [SerializeField] Image _highlight;

    private void Awake()
    {
        _highlight.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isClicked)
        {
            _highlight.gameObject.SetActive(true);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_mouseOnPortrait)
        {
            _isClicked = !_isClicked;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOnPortrait = true;
        _highlight.gameObject.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOnPortrait = false ;
        _highlight.gameObject.SetActive(false);
    }
}
