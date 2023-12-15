using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    static public PlayerController Instance;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;
    [SerializeField] private PlayerInteraction _playerInteraction;

    private void Awake()
    {
        Instance = this;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started && !_playerRotation.IsRotating)
        {
            _playerMovement.SetDirection(context.ReadValue<Vector2>());
        }
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        if (context.started && !_playerMovement.IsMoving)
        {
            _playerRotation.SetDirection((int)context.ReadValue<Vector2>().x);
        }

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {

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
                Destroy(ItemsOnFloor.Instance.ItemsCloseToThePlayer()[0].GameObject());
            }
        }
    }
}
