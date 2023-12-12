using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // THIS CODE IS JUST TO SHOW HOW THAT WORKS

    private void Start()
    {
        Debug.LogWarning("The tester is still in the scene.");
    }

    // Update is called once per frame
    void Update()
    {
        // Open win menu
        if (Input.GetKeyDown(KeyCode.O))
        {
            MenuManager.Instance.OpenMenu(MenuManager.MenuEnum.WinMenu);
        }
        // Close win menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            MenuManager.Instance.CloseMenu(MenuManager.MenuEnum.WinMenu);
        }

        // Open win menu
        if (Input.GetKeyDown(KeyCode.K))
        {
            MenuManager.Instance.OpenMenu(MenuManager.MenuEnum.LoseMenu);
        }
        // Close win menu
        if (Input.GetKeyDown(KeyCode.L))
        {
            MenuManager.Instance.CloseMenu(MenuManager.MenuEnum.LoseMenu);
        }
    }
}