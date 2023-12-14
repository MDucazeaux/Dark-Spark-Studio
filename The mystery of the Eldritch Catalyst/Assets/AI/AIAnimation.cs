using System;
using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private Animator _animator;

    private Vector3 _lookAtPos;

    private void Update()
    {
        _spriteTransform.LookAt(_lookAtPos);
    }

    public void SetLookAtPos(Vector3 pos)
    {
        _lookAtPos = pos;
    }

    public void AnimatorSetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
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
