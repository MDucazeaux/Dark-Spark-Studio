using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction;
    private bool _bIsMoving = false;

    const float c_tileSize = 10;
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
        Vector3 _startingPos = transform.position;
        Vector3 _targetPos = transform.position;
        _targetPos += transform.forward * _direction.y * c_tileSize;
        _targetPos += transform.right * _direction.x * c_tileSize;
        float time = 0.5f; //should be in PlayerStats
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _bIsMoving = false;
        yield return null;
    }
}
