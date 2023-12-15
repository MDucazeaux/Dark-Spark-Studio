using System.Collections;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    [SerializeField] AIAnimation _aiAnimation;
    private Enemy _enemy;

    private bool _canAttack = true;

    [SerializeField] private float _cooldown = 1;
    [SerializeField] private float _distanceAttack = 10;
    private LayerMask _playerLayer;

    private void Awake()
    {
        _playerLayer = LayerMask.GetMask("Player");
    }

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    public void AttackPlayer()
    {
        if (_canAttack)
        {
            CharacterSelection.Instance.Characters[CharacterSelection.Instance.CharactersPlacement[0]].TakeDamage(_enemy.GetDamage());
            CharacterSelection.Instance.Characters[CharacterSelection.Instance.CharactersPlacement[1]].TakeDamage(_enemy.GetDamage());

            StartCoroutine(AttackCooldown());
            StartCoroutine(_aiAnimation.DoAttackAnimation((_cooldown-0.1f) * 0.85f));
        }
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }
}
