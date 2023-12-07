using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _playerMovement.SetDirection(context.ReadValue<Vector2>());
        }
    }
}
