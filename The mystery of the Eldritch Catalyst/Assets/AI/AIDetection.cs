using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class AIDetection : MonoBehaviour
{
    private Transform _transform;

    private PlayerController _playerController;
    private Transform _playerTransform;

    const float c_tileSize = 10;

    [SerializeField]
    private float _detectionRange = c_tileSize * 3;

    private LayerMask _layerEnemy;

    private void Awake()
    {
        _transform = transform;
        _layerEnemy = LayerMask.NameToLayer("Enemy");
    }

    private void Start()
    {
        _playerController = PlayerController.Instance;
        _playerTransform = _playerController.transform;
    }
    public bool CanSeePlayer()
    {
        if (Vector3.Distance(_playerTransform.position, _transform.position) > _detectionRange)
        {
            return false; //to optimize performance
        }

        if (Physics.Raycast(_transform.position, (_playerTransform.position - _transform.position).normalized, out RaycastHit hitInfo, _detectionRange, ~(1 << _layerEnemy)))
        {
            if (hitInfo.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
    public Vector3 GetPlayerPos()
    {
        return _playerTransform.position;
    }

    public bool IsNearPlayer()
    {
        return Vector3.Distance(transform.position, _playerTransform.position) <= c_tileSize + 1;
    }
}
