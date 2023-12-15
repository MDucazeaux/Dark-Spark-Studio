using UnityEngine;

public class TestingScript : MonoBehaviour
{
    // THIS CODE IS JUST TO SHOW HOW THAT WORKS //

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
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.NormalSwordAttack);
        }
        // Close win menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            MenuManager.Instance.CloseMenu(MenuManager.MenuEnum.WinMenu);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.HeavySwordAttack);
        }

        // Open lose menu
        if (Input.GetKeyDown(KeyCode.K))
        {
            MenuManager.Instance.OpenMenu(MenuManager.MenuEnum.LoseMenu);
            StartCoroutine(SoundsManager.Instance.PlayMusicEndlessly(SoundsManager.TypesOfMusics.DonjonThemes));
        }
        // Close lose menu
        if (Input.GetKeyDown(KeyCode.L))
        {
            MenuManager.Instance.CloseMenu(MenuManager.MenuEnum.LoseMenu);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.EvilWizardIdle);
        }
    }
}