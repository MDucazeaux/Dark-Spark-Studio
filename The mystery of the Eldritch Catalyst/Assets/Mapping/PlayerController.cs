using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    PlayerMovement _playerMovement;
    PlayerRotation _playerRotation;
    PlayerInteraction _playerInteraction;
    // Loot variable
    // Basic attack variable
    // Special attack variable
    MenuManager _menuManager;
    #endregion

    #region Methods
    private void Start()
    {
        _playerMovement = PlayerMovement.Instance;
        _playerRotation = PlayerRotation.Instance;
        _playerInteraction = PlayerInteraction.Instance;
        // Loot variable setting
        // Basic attack variable setting
        // Special attack variable setting
        _menuManager = MenuManager.Instance;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started && !_playerRotation.IsRotating)
        {
            _playerMovement.SetMovementDirection(context.ReadValue<int>());
        }
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.started && !_playerMovement.IsMoving)
        {
            _playerRotation.SetRotationDirection(context.ReadValue<int>());
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerInteraction.Interact();
        }
    }

    public void OnLooting(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // TO DO : Loot
        }
    }

    public void OnBasicAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // TO DO : Basic attack
        }
    }

    public void OnSpecialAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            // TO DO : Special attack
        }
    }

    public void OnPausing(InputAction.CallbackContext context)
    {
        // If the Pause menu is already open, we close it.
        if (context.started && _menuManager.IsMenuOpen(MenuManager.MenuEnum.PauseMenu))
        {
            _menuManager.CloseMenu(MenuManager.MenuEnum.PauseMenu);
        }
        // Else if no other menus are opened then we open the Pause menu
        else if (context.started && !_menuManager.IsAnyMenuOpen())
        {
            _menuManager.OpenMenu(MenuManager.MenuEnum.PauseMenu);
        }
    }
    #endregion
}