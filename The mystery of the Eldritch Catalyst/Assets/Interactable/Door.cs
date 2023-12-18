using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;
    [SerializeField] private Transform _parentTransform;

    [SerializeField] private GameObject _breakParticles;

    [SerializeField] private List<MeshCollider> colliders;

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
        float _startRotation = _parentTransform.rotation.eulerAngles.y;
        float _endRotation = _startRotation - 90;
        float time = 2f;
        float _elapsedTime = 0;
        Vector3 offsetpos = _parentTransform.position;
        offsetpos += _parentTransform.right * -0.01f; //offset the plane so texture doesn't clip
        _parentTransform.position = offsetpos;
        while (_elapsedTime < time)
        {
            float _angle = Mathf.LerpAngle(_startRotation, _endRotation, (_elapsedTime / time));
            _parentTransform.rotation = Quaternion.Euler(_parentTransform.rotation.eulerAngles.x, _angle, _parentTransform.rotation.eulerAngles.z);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _parentTransform.rotation = Quaternion.Euler(_parentTransform.rotation.eulerAngles.x, _endRotation, _parentTransform.rotation.eulerAngles.z);
    }

    public override void BreakInteractable()
    {
        transform.GetComponent<MeshCollider>().enabled = false;
        StartCoroutine(BreakAnimation());
    }

    private IEnumerator BreakAnimation()
    {
        _bIsOpened = true;

        if (_breakParticles)
        {
            Instantiate(_breakParticles, _parentTransform.position, _parentTransform.rotation);
        }

        float _startRotation = _parentTransform.rotation.eulerAngles.x;
        float _endRotation = _startRotation - 90;
        float time = 0.25f;
        float _elapsedTime = 0;
        Vector3 offsetpos = _parentTransform.position;
        offsetpos += _parentTransform.up * 0.01f; //offset the plane so texture doesn't clip
        _parentTransform.position = offsetpos;
        while (_elapsedTime < time)
        {
            float _angle = Mathf.LerpAngle(_startRotation, _endRotation, (_elapsedTime / time));
            _parentTransform.rotation = Quaternion.Euler(_angle, _parentTransform.rotation.eulerAngles.y, _parentTransform.rotation.eulerAngles.z);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }

    public void Unlock()
    { _bIsLocked = false; }
}
