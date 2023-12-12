using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Button : Interactable
{
    private Transform _transform;
    private bool _bIsActivated = false;
    [SerializeField] private bool _bIsHidden = true;

    private void Awake()
    {
        _transform = transform;
    }
    public override void Interaction()
    {
        if (!_bIsHidden && !_bIsActivated)
        {
            StartCoroutine(Activate());
        }
    }

    public override bool CanInteract()
    {
        return !_bIsActivated;
    }
    private IEnumerator Activate()
    {
        _bIsActivated = true;
        Vector3 _startingPos = _transform.position;
        Vector3 _targetPos = _startingPos;
        _targetPos += _transform.right * 0.4f;

        float time = 0.35f;
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            _transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = _targetPos;
        yield return null;
    }

    public bool IsHidden { get { return _bIsHidden; } set { _bIsHidden = value; } }
}
