using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortraitScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private SelectionUICharacter _SelectionUICharacter;
    private CharacterSelection _CharacterSelection;

    private bool _mouseOnPortrait = false;

    [SerializeField] private Image _highlight;
    [SerializeField] private Image _hover;
    [SerializeField] private Image _background;
    [SerializeField] private int _portraitID = 0;

    private Color _selectedColor = new Color(124f / 255f, 206f / 255f, 255f / 255f);
    private Color _normalColor = new Color(255f / 255f, 255f / 255f, 255f / 255f);


    private void Awake()
    {
        _highlight.gameObject.SetActive(false);
        _hover.gameObject.SetActive(false);
    }

    private void Start()
    {
        _SelectionUICharacter = SelectionUICharacter.Instance;
        _CharacterSelection = CharacterSelection.Instance;
    }

    private void Update()
    {
        _highlight.gameObject.SetActive(_SelectionUICharacter.IsSelectedPlacement(_portraitID));
        if (_CharacterSelection.IsSelected(_portraitID))
        {
            _background.color = _selectedColor;
        }
        else
        {
            _background.color = _normalColor;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        _SelectionUICharacter.SelectPortrait(_portraitID);
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
