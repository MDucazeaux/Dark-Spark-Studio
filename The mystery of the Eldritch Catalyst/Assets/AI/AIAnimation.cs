using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private Animator _animator;

    private Transform _transform;

    private bool _bisAttacking = false;

    private void Awake()
    {
        _transform = transform;
    }

    public void AnimatorSetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public bool AnimatorGetBool(string name)
    {
        return _animator.GetBool(name);
    }

    public void SetAnimatorSpeed(float speed)
    {
        _animator.speed = speed;
    }

    public IEnumerator DoAttackAnimation(float time)
    {
        if (_bisAttacking)
        {
            yield break;
        }

        _bisAttacking = true;

        Vector3 _startingPos = _spriteTransform.localPosition;
        Vector3 _targetPos =  _spriteTransform.localPosition + -_spriteTransform.forward*1f;

        float firstAnim = time * 0.10f;
        float secondAnim = time * 0.45f;
        float thirdAnim = time * 0.45f;

        float _elapsedTime = 0;
        while (_elapsedTime < firstAnim)
        {
            _spriteTransform.localPosition = Vector3.Lerp(_startingPos, _targetPos, (_elapsedTime / (firstAnim * 0.5f)));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        _elapsedTime = 0;
        while (_elapsedTime < secondAnim)
        {
            _elapsedTime += Time.deltaTime;
            yield return null;
        }

        _elapsedTime = 0;
        while (_elapsedTime < thirdAnim)
        {
            _spriteTransform.localPosition = Vector3.Lerp(_targetPos, _startingPos, (_elapsedTime / (thirdAnim * 0.5f)));
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        _spriteTransform.localPosition = _startingPos;
        _bisAttacking = false;

        yield return null;
    }

    public void PlayAnimation(string name)
    {
        switch (name)
        {
            case "Idle":
                break;
            case "Walking":
                break;
            case "Attacking":
                break;
            case "Dying":
                break;
        }
    }
}
