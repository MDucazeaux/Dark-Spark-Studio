using UnityEngine;
//using static UnityEditor.Progress;

public class TooltipSystem : MonoBehaviour
{
    public static TooltipSystem Instance;

    [SerializeField]
    private Tooltip _tooltip;

    private void Awake()
    {
        Instance = this;
    }

    public void Show(string content, string header = "")
    {
        _tooltip.SetText(content, header);
        _tooltip.gameObject.SetActive(true);
    }
    public void Hide()
    {
        _tooltip.gameObject.SetActive(false);
    }
}