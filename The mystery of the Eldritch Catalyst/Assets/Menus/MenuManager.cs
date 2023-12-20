using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    
    #region Variables
    public static MenuManager Instance;

    [SerializeField] MenuStruct _menuStruct;

    [Serializable]
    public struct MenuStruct
    {
        [Header("PauseMenu")]
        public GameObject PauseMenu;
        public GameObject PauseMenuSelectedButton;
        [Header("WinMenu")]
        public GameObject WinMenu;
        public GameObject WinMenuSelectedButton;
        [Header("LoseMenu")]
        public GameObject LoseMenu;
        public GameObject LoseMenuSelectedButton;
    }

    [SerializeField]
    private GameObject _settingsMenu;

    public enum MenuEnum
    {
        PauseMenu,
        WinMenu,
        LoseMenu,
        SettingsMenu
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

    private void Start()
    {
        _settingsMenu = Settings.Instance.gameObject;
    }

    /// <summary> Return if the menu given is open </summary>
    public bool IsMenuOpen(MenuEnum menu)
    {
        switch (menu)
        {
            case MenuEnum.PauseMenu:
                if (_menuStruct.PauseMenu.activeSelf == true)
                    return true;
                else
                    return false;

            case MenuEnum.WinMenu:
                if (_menuStruct.WinMenu.activeSelf == true)
                    return true;
                else
                    return false;

            case MenuEnum.LoseMenu:
                if (_menuStruct.LoseMenu.activeSelf == true)
                    return true;
                else
                    return false;
            case MenuEnum.SettingsMenu:
                if (_settingsMenu.activeSelf == true)
                    return true;
                else
                    return false;

            

            default:
                Debug.LogError($"ERROR ! The {menu} is not planned in the switch statement.");
                return false;
        }
    }

    /// <summary> Return if any menu given is open </summary>
    public bool IsAnyMenuOpen()
    {
        if (_menuStruct.PauseMenu.activeSelf == true)
            return true;
        else if (_menuStruct.WinMenu.activeSelf == true)
            return true;
        else if (_menuStruct.LoseMenu.activeSelf == true)
            return true;
        else if (_settingsMenu.activeSelf == true)
            return true;
        else
        {
            return false;
        }
    }

    /// <summary> Open the given menu </summary>
    public void OpenMenu(MenuEnum menu)
    {
        // Stop time so the game can't do anything
        Time.timeScale = 0.0f;

        // Show the player mouse cursor, so he can use it to click on buttons
        //Cursor.visible = true;

        // Show the menu given, and select the correspondant button
        switch (menu)
        {
            case MenuEnum.PauseMenu:
                _menuStruct.PauseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_menuStruct.PauseMenuSelectedButton);
                return;

            case MenuEnum.WinMenu:
                _menuStruct.WinMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_menuStruct.WinMenuSelectedButton);
                return;

            case MenuEnum.LoseMenu:
                _menuStruct.LoseMenu.SetActive(true);
                EventSystem.current.SetSelectedGameObject(_menuStruct.LoseMenuSelectedButton);
                return;

            default:
                Debug.LogError($"ERROR ! The {menu} is not planned in the switch statement.");
                return;
        }
    }

    /// <summary> Close the given menu </summary>
    public void CloseMenu(MenuEnum menu)
    {
        // Make the going at his normal speed
        Time.timeScale = 1f;

        // Hide the player mouse cursor
        //Cursor.visible = false;

        // Hide the menu given
        switch (menu)
        {
            case MenuEnum.PauseMenu:
                _menuStruct.PauseMenu.SetActive(false);
                return;

            case MenuEnum.WinMenu:
                _menuStruct.WinMenu.SetActive(false);
                return;

            case MenuEnum.LoseMenu:
                _menuStruct.LoseMenu.SetActive(false);
                return;
            default:
                Debug.LogError($"ERROR ! The {menu} is not planned in the switch statement.");
                return;
        }
    }

    public void CloseAllMenu()
    {
        Time.timeScale = 1f;
        _menuStruct.PauseMenu.SetActive(false);
        _menuStruct.WinMenu.SetActive(false);
        _menuStruct.LoseMenu.SetActive(false);
        _settingsMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        Settings.Instance.OpenSettings();
    }
    #endregion
}