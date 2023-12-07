using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;
    private Vector2 _direction;
    private bool _bIsMoving = false;

    const float c_tileSize = 10;

    private void Awake()
    {
        _transform = transform;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void Update()
    {
        if (_direction != Vector2.zero && !_bIsMoving)
        {
            _bIsMoving = true;
            StartCoroutine(Move());
            _direction = Vector2.zero;
        }
    }

    private IEnumerator Move()
    {
        Vector3 _startingPos = _transform.position;
        Vector3 _targetPos = _transform.position;
        _targetPos += _transform.forward * _direction.y * c_tileSize;
        _targetPos += _transform.right * _direction.x * c_tileSize;
        float time = 0.5f; //should be in PlayerStats
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            _transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _bIsMoving = false;
        yield return null;
    }

    public bool IsMoving { get { return _bIsMoving; } }
}
