using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    static public PlayerController Instance;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PlayerInteraction _playerInteraction;
    [SerializeField] private MenuManager _menuManager;
    [SerializeField] private PickUpText _pickUpText;

    private Vector2 _playerDirection = Vector2.zero;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!_playerRotation.IsRotating)
        {
            _playerMovement.SetDirection(_playerDirection);
        }
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if ((context.ReadValue<Vector2>()).magnitude <= 1)
            {
                _playerDirection = context.ReadValue<Vector2>();
            }
        }
        else if (context.canceled)
        {
            _playerDirection = Vector2.zero;
        }
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.started && _playerDirection == Vector2.zero && !_playerMovement.IsMoving)
        {
            _playerRotation.SetDirection((int)context.ReadValue<Vector2>().x);
        }

    }

    public void OnActionOne(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ActionButton.Instance.ActionOne();
        }
    }

    public void OnActionTwo(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ActionButton.Instance.ActionTwo();
        }
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerInteraction.Interact();
        }
    }

    public void OnPickUp(InputAction.CallbackContext context)
    {
        if (context.started && !_playerMovement.IsMoving)
        {
            if (ItemsOnFloor.Instance.ItemsCloseToThePlayer().Count > 0 && 
                !Inventory.Instance.InventoryIsFull())
            {
                Inventory.Instance.AddItem(ItemsOnFloor.Instance.ItemsCloseToThePlayer()[0].itemData);
                _pickUpText.StartShowText();
                Destroy(ItemsOnFloor.Instance.ItemsCloseToThePlayer()[0].GameObject());
            }
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
}
