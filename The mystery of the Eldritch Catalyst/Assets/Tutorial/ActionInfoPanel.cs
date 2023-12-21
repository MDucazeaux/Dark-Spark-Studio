using UnityEngine;

public class ActionInfoPanel : MonoBehaviour
{
    public static ActionInfoPanel Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenInfo()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        Show();
    }

    public void CloseInfo()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Hide()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void Show()
    {
        transform.parent.gameObject.SetActive(true);
    }
}
