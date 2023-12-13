using UnityEngine;

public class AIDetection : MonoBehaviour
{
    private PlayerController _playerController;
    private Transform _playerTransform;

    private void Start()
    {
        _playerController = PlayerController.Instance;
        _playerTransform = _playerController.transform;
    }

    public bool CanSeePlayer()
    {
        return true;
    }

    public Vector3 GetPlayerPos()
    {
        return _playerTransform.position;
    }
}
