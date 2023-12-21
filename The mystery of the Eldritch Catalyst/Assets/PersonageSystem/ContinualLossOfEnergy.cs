using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinualLossOfEnergy : MonoBehaviour
{
    public static ContinualLossOfEnergy Instance;

    #region Variables
    [SerializeField] float _timeBetweenEnemySteal = 5f;
    [SerializeField] float _energyStolen = 1f;

    MenuManager _menuManager;
    #endregion

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    #region Methods
    private void Start()
    {
        _menuManager = MenuManager.Instance;

        StartCoroutine(EndlessLossOfEnergy(_timeBetweenEnemySteal, _energyStolen));
    }

    IEnumerator EndlessLossOfEnergy(float timeBetweenEnemySteal, float energyStolen)
    {
        while ( !( _menuManager.IsMenuOpen(MenuManager.MenuEnum.LoseMenu) || _menuManager.IsMenuOpen(MenuManager.MenuEnum.WinMenu) ) )
        {
            yield return new WaitForSeconds(timeBetweenEnemySteal);

            foreach (Character character in CharacterSelection.Instance.CharactersList())
            {
                if (character.GetStamina() > 0)
                    character.UseStamina(energyStolen);
                else 
                    character.TakeDamage(energyStolen);
            }
        }
    }
    #endregion
}