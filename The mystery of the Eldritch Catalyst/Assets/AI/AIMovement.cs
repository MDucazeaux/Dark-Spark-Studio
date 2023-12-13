using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    private Transform _transform;

    private Vector3 _targetPos;
    private bool _canMove = true;

    private float _moveTime = 1.25f; // PLACEHOLDER!!! modify when Enemy class are done

    private LayerMask _layerWall = LayerMask.NameToLayer("Wall");

    const float c_tileSize = 10;

    private void Awake()
    {
        _transform = transform;
    }
    public void SetTargetTo(Vector3 pos)
    {
        _targetPos = pos;
    }

    public void Move()
    {
        if (_canMove)
        {
            float deltaX = _targetPos.x - _transform.position.x;
            float deltaZ = _targetPos.z - _transform.position.z;

            Vector3 destination;
            if (Mathf.Abs(deltaX) > Mathf.Abs(deltaZ)) 
            {
                destination = _transform.position + (new Vector3(Mathf.Sign(deltaX), 0, 0) * c_tileSize);
                if (!CanMoveTo(destination))
                {
                    destination = _transform.position + (new Vector3(0, 0, Mathf.Sign(deltaZ)) * c_tileSize);
                    if (!CanMoveTo(destination))
                    {
                        destination = _transform.position - (new Vector3(0, 0, Mathf.Sign(deltaZ)) * c_tileSize);
                    }
                }
            }
            else
            {
                destination = _transform.position + (new Vector3(0, 0, Mathf.Sign(deltaZ)) * c_tileSize);
                if (!CanMoveTo(destination))
                {
                    destination = _transform.position + (new Vector3(Mathf.Sign(deltaX), 0, 0) * c_tileSize);
                    if (!CanMoveTo(destination))
                    {
                        destination = _transform.position - (new Vector3(Mathf.Sign(deltaX), 0, 0) * c_tileSize);
                    }
                }
            }
            if (CanMoveTo(destination))
            {
                StartCoroutine(MovingTo(destination));
            }
        }
    }

    private IEnumerator MovingTo(Vector3 pos)
    {
        _canMove = false;
        Vector3 _startingPos = _transform.position;
        float _elapsedTime = 0;
        while (_elapsedTime < _moveTime)
        {
            _transform.position = Vector3.Lerp(_startingPos, pos, (_elapsedTime / _moveTime));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = pos;

        _canMove = true;
        yield return null;
    }

    private bool CanMoveTo(Vector3 target)
    {
        return (!Physics.Raycast(_transform.position, (target - _transform.position).normalized, c_tileSize, ~1 << _layerWall));
    }
}
