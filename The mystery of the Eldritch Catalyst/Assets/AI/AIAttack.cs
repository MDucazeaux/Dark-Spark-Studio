using UnityEngine;

public class AIAttack : MonoBehaviour
{
    private PlayerController _playerController;

    private void Start()
    {
        _playerController = PlayerController.Instance;
    }
}
