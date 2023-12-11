using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PortraitScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private SelectionUICharacter _SelectionUICharacter;

    private bool _mouseOnPortrait = false;

    [SerializeField] private Image _highlight;
    [SerializeField] private Image _hover;
    [SerializeField] private int _portraitID = 0;

    private void Awake()
    {
        _highlight.gameObject.SetActive(false);
        _hover.gameObject.SetActive(false);
    }

    private void Start()
    {
        _SelectionUICharacter = SelectionUICharacter.Instance;
    }

    private void Update()
    {
        _highlight.gameObject.SetActive(_SelectionUICharacter.IsSelected(_portraitID));
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_mouseOnPortrait)
        {
            _SelectionUICharacter.SelectPortrait(_portraitID);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOnPortrait = true;
        _hover.gameObject.SetActive(true);

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOnPortrait = false ;
        _hover.gameObject.SetActive(false);
    }
}
