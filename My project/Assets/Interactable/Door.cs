using System.Collections;
using UnityEngine;

public class Door : Interactable
{
    private bool _bIsOpened = false;
    [SerializeField] private bool _bIsLocked = false;
    [SerializeField] private Transform _parentTransform;

    public override void Interaction()
    {
        if (!_bIsLocked)
        {
            if (!_bIsOpened)
            {
                StartCoroutine(Open());
            }
        }
    }


    private void Update()
    {
        if (!_bIsLocked)
        {
            if (!_bIsOpened)
            {
                StartCoroutine(Open());
            }
        }
    }
    private IEnumerator Open()
    {
        _bIsOpened = true;
        float _startRotation = _parentTransform.rotation.eulerAngles.y;
        float _endRotation = _startRotation - 90;
        float time = 2f;
        float _elapsedTime = 0;
        Vector3 offsetpos = _parentTransform.position;
        offsetpos += _parentTransform.forward * -0.01f; //offset the plane so texture doesn't clip
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

    public bool IsLocked { get { return _bIsLocked; } set { _bIsLocked = value; } }
}
