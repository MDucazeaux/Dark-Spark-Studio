using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

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
}
