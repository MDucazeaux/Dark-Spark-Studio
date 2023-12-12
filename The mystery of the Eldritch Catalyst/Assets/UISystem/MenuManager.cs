using System;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    #region Variables
    public static MenuManager Instance;

    [SerializeField] MenuList _menuList;

    [Serializable]
    public struct MenuList
    {
        public GameObject PauseMenu;
        public GameObject WinMenu;
        public GameObject LoseMenu;
    }

    public enum MenuEnum
    {
        PauseMenu,
        WinMenu,
        LoseMenu
    }
    #endregion

    #region Methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenMenu(MenuEnum menuEnum)
    {
        // Stop time so the game can't do anything
        Time.timeScale = 0.0f;

        // Show the player mouse cursor, so he can use it to click on buttons
        Cursor.visible = true;

        // Show the menu given
        switch (menuEnum)
        {
            case MenuEnum.PauseMenu:
                _menuList.PauseMenu.SetActive(true);
                return;

            case MenuEnum.WinMenu:
                _menuList.WinMenu.SetActive(true);
                return;

            case MenuEnum.LoseMenu:
                _menuList.LoseMenu.SetActive(true);
                return;

            default:
                Debug.LogError($"ERROR ! The {menuEnum} is not planned in the switch statement.");
                return;
        }
    }

    public void CloseMenu(MenuEnum menuEnum)
    {
        // Make the going at his normal speed
        Time.timeScale = 1f;

        // Hide the player mouse cursor
        Cursor.visible = false;

        // Hide the menu given
        switch (menuEnum)
        {
            case MenuEnum.PauseMenu:
                _menuList.PauseMenu.SetActive(false);
                return;

            case MenuEnum.WinMenu:
                _menuList.WinMenu.SetActive(false);
                return;

            case MenuEnum.LoseMenu:
                _menuList.LoseMenu.SetActive(false);
                return;

            default:
                Debug.LogError($"ERROR ! The {menuEnum} is not planned in the switch statement.");
                return;
        }
    }
    #endregion
}