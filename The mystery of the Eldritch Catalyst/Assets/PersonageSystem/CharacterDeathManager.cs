using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterDeathManager : MonoBehaviour
{
    #region Variables
    public static CharacterDeathManager Instance;

    List<Character> _characterList;
    List<bool> _isCharacterDead;
    #endregion

    #region Methods
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _characterList = GetComponent<CharacterSelection>().CharactersList;

        // Creating and setting all the bollean to false
        _isCharacterDead = new();

        for (int i = 0; i < _characterList.Count; i++)
        {
            _isCharacterDead.Add(false);
        }
    }

    public void AreAllCharactersDead()
    {
        for (int i = 0; i < _characterList.Count; i++) 
        {
            _isCharacterDead[i] = _characterList[i].IsDead;
        }

        // If all the booleans are at True then the condition is True
        if (_isCharacterDead.All(boolean => boolean))
        {
            MenuManager.Instance.OpenMenu(MenuManager.MenuEnum.LoseMenu);
        }
    }
    #endregion
}