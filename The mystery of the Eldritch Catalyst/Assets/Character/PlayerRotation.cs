using System.Collections;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private int _direction;
    private bool _bIsRotating = false;

    public void SetDirection(int direction)
    {
        _direction = direction;
    }

    private void Update()
    {
        if (_direction != 0 && !_bIsRotating)
        {
            _bIsRotating = true;
            StartCoroutine(Rotate());
            _direction = 0;
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.CharactersRotate, 1);
        }
    }

    private IEnumerator Rotate()
    {
        float _startingRot = transform.eulerAngles.y;
        float _targetRot = _startingRot + _direction * 90;
        float time = 0.5f; //should be in PlayerStats
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Lerp(_startingRot, _targetRot, (_elapsedTime / time)), 0);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.eulerAngles = new Vector3(0, _targetRot, 0);
        _bIsRotating = false;
        yield return null;
    }

    public bool IsRotating { get { return _bIsRotating; } }
}
