using System.Collections;
using UnityEngine;

public class Gate : Interactable
{
    private Transform _transform;
    [SerializeField] private bool _bIsLocked = true;
    private bool _bIsOpened = false;

    private void Awake()
    {
        _transform = transform;
    }

    public override void Interaction()
    {
        if (!_bIsLocked && !_bIsOpened)
        {
            StartCoroutine(Open());
        }
    }

    public override bool CanInteract()
    {
        return !_bIsOpened;
    }
    private IEnumerator Open()
    {
        _bIsOpened = true;
        Vector3 _startingPos = _transform.position;
        Vector3 _targetPos = _startingPos;
        _targetPos.y += 10;

        float time = 2f;
        float _elapsedTime = 0;
        while (_elapsedTime < time)
        {
            _transform.position = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / time));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _transform.position = _targetPos;
    }
    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }

    public void Unlock()
    { _bIsLocked = false; }
}
