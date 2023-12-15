using UnityEngine;

public class AIAnimation : MonoBehaviour
{
    [SerializeField] private Transform _spriteTransform;
    [SerializeField] private Animator _animator;

    public void AnimatorSetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void DoAttackAnimation()
    {

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
