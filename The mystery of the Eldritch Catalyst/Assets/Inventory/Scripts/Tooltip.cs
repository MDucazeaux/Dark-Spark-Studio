using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Tooltip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _headerField;

    [SerializeField]
    private TextMeshProUGUI _contentField;

    [SerializeField]
    private LayoutElement _layoutElement;

    [SerializeField]
    private int _maxCharacter;

    [SerializeField]
    private RectTransform _rectTransform;

    private Transform _transform;

    public void Start()
    {
        _transform = transform;
    }

    public void SetText(string content, string header = "")
    {
        if (header == "")
        {
            _headerField.gameObject.SetActive(false);
        }
        else
        {
            _headerField.gameObject.SetActive(true);
            _headerField.text = header;
        }

        _contentField.text = content;

        int headerLength = _headerField.text.Length;
        int bodyLength = _contentField.text.Length;

        _layoutElement.enabled = (headerLength > _maxCharacter || bodyLength > _maxCharacter) ? true : false;
    }

    private void Update()
    {
        _transform.position = Input.mousePosition;
    }
}
