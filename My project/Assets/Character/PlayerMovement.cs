using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _direction;
    private bool _bIsMoving = false;
    private LayerMask _layerWall;
    private LayerMask _layerEnenmy;

    const float c_tileSize = 10;

    private void Awake()
    {
        _transform = transform;
        _layerWall = LayerMask.NameToLayer("Wall");
        _layerEnenmy = LayerMask.NameToLayer("Enemy");
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
            }
            _direction = Vector2.zero;
        }
    }

    private bool CanMoveTo(Vector3 target)
    {
        return (!Physics.Raycast(_transform.position, (target - _transform.position).normalized, c_tileSize));
    }
    private IEnumerator Move(Vector3 _targetPos)
    {
        Vector3 _startingPos = _transform.position;
        
        float time = 0.5f; //should be in PlayerStats
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            _transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time)); //move camera here instead of transform
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = _targetPos;
        //set camera local pos to 0
        _bIsMoving = false;
        yield return null;
    }

    public bool IsMoving { get { return _bIsMoving; } }
}
