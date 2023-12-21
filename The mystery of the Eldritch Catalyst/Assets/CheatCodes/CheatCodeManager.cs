using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheatCodeManager : MonoBehaviour
{
    #region Variables
    [Header("Controls :")]
    [SerializeField] KeyCode _giveEquipmentControl;
    [SerializeField] KeyCode _invisibilityControl;
    [SerializeField] KeyCode _teleportationToMinotaurControl;
    [SerializeField] KeyCode _teleportationToBossControl;

    [Header("CheatText")]
    [SerializeField] GameObject _cheatShowing;
    [SerializeField] TextMeshProUGUI _cheatTextPrefab;
    [SerializeField] float _cheatTextShowingTime = 2;

    [Header("Teleportation references")]
    [SerializeField] GameObject _player;
    [SerializeField] AllTeleportationTarget _allTeleportationTarget;

    [Header("GiveItems")]
    [SerializeField] int _numberOfTimeYouWantThis;
    [SerializeField] List<GameObject> _itemGiven;

    List<Character> _characterList;
    bool _isInvisibilityEnabled;

    #region Enum
    enum CheatCodes
    {
        GiveItems,
        InvisibilityON,
        InvisibilityOFF,
        TeleportationToMinotaur,
        TeleportationToBoss
    }

    enum TeleportationTarget
    {
        Minotaur,
        Boss
    }
    #endregion

    #region Struct
    [Serializable]
    struct AllTeleportationTarget
    {
        public GameObject _minotaurTeleporterWaypoint;
        public GameObject _bossTeleporterWaypoint;
    }
    #endregion
    #endregion

    #region Methods

    void Start()
    {
        _characterList = _player.GetComponentInChildren<CharacterSelection>().CharactersList();
    }

    void Update()
    {
        // Give items
        if (Input.GetKeyDown(_giveEquipmentControl))
        {
            GiveItems(_numberOfTimeYouWantThis);
        }

        // Invisibility
        if (Input.GetKeyDown(_invisibilityControl))
        {
            if (!_isInvisibilityEnabled)
            {
                _isInvisibilityEnabled = true;
                ChangeInvisibily(true);
            }
            else
            {
                _isInvisibilityEnabled = false;
                ChangeInvisibily(false);
            } 
        }

        // Teleportation to minotaur
        if (Input.GetKeyDown(_teleportationToMinotaurControl))
        {
            Teleport(TeleportationTarget.Minotaur);
        }

        // Teleportation to boss
        if (Input.GetKeyDown(_teleportationToBossControl))
        {
            Teleport(TeleportationTarget.Boss);
        }
    }

    void GiveItems(int numberOfTime)
    {
        // We need to instantiate items in the world to put them in the inventory
        for (int i = 0; i < numberOfTime; i++)
        {
            for (int j = 0; j < _itemGiven.Count; j++)
            {
                if (!Inventory.Instance.InventoryIsFull())
                {
                    GameObject item = Instantiate(_itemGiven[j]);

                    Inventory.Instance.AddItem(item.GetComponent<Item>().itemData);

                    Destroy(item);
                }
            }
        }

        StartCoroutine (ShowCheatCode(CheatCodes.GiveItems));
    }

    void ChangeInvisibily(bool isEnable)
    {
        // Change invisibility for all characters
        for (int i = 0;  i < _characterList.Count; i++)
        {
            _characterList[i].ChangeEndlessProtection(isEnable);
        }

        // Showing the activation of the cheat code
        if (isEnable)
            StartCoroutine(ShowCheatCode(CheatCodes.InvisibilityON));
        else
            StartCoroutine(ShowCheatCode(CheatCodes.InvisibilityOFF));
    }

    void Teleport(TeleportationTarget teleportationTarget)
    {
        switch (teleportationTarget)
        {
            case TeleportationTarget.Minotaur:
                _player.transform.position = _allTeleportationTarget._minotaurTeleporterWaypoint.transform.position;
                StartCoroutine(ShowCheatCode(CheatCodes.TeleportationToMinotaur));
                break;

            case TeleportationTarget.Boss:
                _player.transform.position = _allTeleportationTarget._bossTeleporterWaypoint.transform.position;
                StartCoroutine(ShowCheatCode(CheatCodes.TeleportationToBoss));
                break;
        }
    }

    IEnumerator ShowCheatCode(CheatCodes cheatCode, float cheatTextShowingTime = 2)
    {
        TextMeshProUGUI cheatText = Instantiate(_cheatTextPrefab, _cheatShowing.transform);

        switch (cheatCode)
        {
            case CheatCodes.GiveItems:
                cheatText.text = "Cheated items has been given";
                break;

            case CheatCodes.InvisibilityON:
                cheatText.text = "You are now invincible";
                break;

            case CheatCodes.InvisibilityOFF:
                cheatText.text = "You are no longer invincible";
                break;

            case CheatCodes.TeleportationToMinotaur:
                cheatText.text = "You have been teleported to the minotaur room";
                break;

            case CheatCodes.TeleportationToBoss:
                cheatText.text = "You have been teleported to the boss room";
                break;
        }

        yield return new WaitForSeconds(cheatTextShowingTime);

        Destroy(cheatText.gameObject);
    }
    #endregion
}