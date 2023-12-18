using UnityEngine;

public class HealChoicePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _healChoicePanel;


    public static HealChoicePanel Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenHealChoicePanel()
    {
        _healChoicePanel.transform.position = Input.mousePosition;
        _healChoicePanel.SetActive(true);
    }

    public void CloseHealChoicePanel()
    {
        _healChoicePanel.SetActive(false);
    }
}