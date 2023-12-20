using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    [SerializeField] private Transform _collisionTransform;

    private Transform _transform;
    private Vector2 _direction;
    private bool _bIsMoving = false;
    private LayerMask _layerWall;
    private LayerMask _layerEnemy;

    const float c_tileSize = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        _transform = transform;
        _layerWall = LayerMask.NameToLayer("Wall");
        _layerEnemy = LayerMask.NameToLayer("Enemy");
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void Update()
    {
        if (_direction != Vector2.zero && !_bIsMoving)
        {
            Vector3 _targetPos = _transform.position;
            _targetPos += _transform.forward * _direction.y * c_tileSize;
            _targetPos += _transform.right * _direction.x * c_tileSize;
            if (CanMoveTo(_targetPos))
            {
                _bIsMoving = true;
                StartCoroutine(Move(_targetPos));
                SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.CharactersMoves, 1);
            }
            _direction = Vector2.zero;
        }
    }

    private bool CanMoveTo(Vector3 target)
    {
        return (!Physics.Raycast(_transform.position, (target - _transform.position).normalized, c_tileSize, 1 << _layerWall | 1 << _layerEnemy));
    }
    private IEnumerator Move(Vector3 _targetPos)
    {
        Vector3 _startingPos = _transform.position;
        
        float time = 0.5f; //should be in PlayerStats
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            _collisionTransform.position = _targetPos;
            _transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = _targetPos;
        _collisionTransform.position = _targetPos;
        _bIsMoving = false;
    }

    public bool IsMoving { get { return _bIsMoving; } }
}
