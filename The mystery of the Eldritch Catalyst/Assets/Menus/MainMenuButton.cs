using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _button;
    private Transform _transform;
    [SerializeField] private Transform _collision;

    private Vector3 _normalPosition;
    private Vector3 _hoverPosition;
    private bool b_isHovered = false;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _transform = GetComponent<Transform>();
        _normalPosition = _transform.position;
        _hoverPosition = _transform.position + new Vector3(-100, 0, 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        b_isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        b_isHovered = false;
    }

    private void Update()
    {
        if (b_isHovered || EventSystem.current.currentSelectedGameObject == gameObject)
        {
            _transform.position = Vector3.Lerp(_transform.position, _hoverPosition, 4f * Time.deltaTime);
        }
        else
        {
            _transform.position = Vector3.Lerp(_transform.position, _normalPosition, 4f * Time.deltaTime);
        }

        if (_collision != null)
        {
            _collision.position = _normalPosition;
        }
    }
}
