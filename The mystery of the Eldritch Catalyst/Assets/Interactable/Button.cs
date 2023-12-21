using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Interactable
{
    private Transform _transform;
    private bool _bIsActivated = false;
    [SerializeField] private bool _bIsHidden = true;

    [SerializeField] private List<Gate> _connectedGates = new List<Gate>();

    private void Awake()
    {
        _transform = transform;
    }
    public override void Interaction()
    {
        if (!_bIsHidden && !_bIsActivated)
        {
            StartCoroutine(Activate());
            for (int i = 0; i < _connectedGates.Count; i++)
            {
                StartCoroutine(_connectedGates[i].Open());
            }
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

    public override void BreakInteractable(bool alternate = false)
    {
    }

    public bool IsHidden { get { return _bIsHidden; } set { _bIsHidden = value; } }

    public bool IsActivated {  get { return _bIsActivated; } }
}
