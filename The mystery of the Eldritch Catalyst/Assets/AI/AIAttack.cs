using System.Collections;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    private PlayerController _playerController;
    [SerializeField] AIAnimation _aiAnimation;

    private bool _canAttack = true;

    [SerializeField] private float _cooldown = 1;

    private void Start()
    {
        _playerController = PlayerController.Instance;
    }

    public void AttackPlayer()
    {
        if (_canAttack )
        {
            Debug.Log("Enemy Attacked at " + Time.time);
            StartCoroutine(AttackCooldown());
            _aiAnimation.DoAttackAnimation();
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }
}
