using System.Collections;
using UnityEngine;

public class AIAttack : MonoBehaviour
{
    [SerializeField] AIAnimation _aiAnimation;
    private Enemy _enemy;

    private bool _canAttack = true;

    private float _cooldown = 1;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _cooldown = _enemy.GetCoolDownAttack();
    }

    public void AttackPlayer()
    {
        if (_canAttack)
        {
            StartCoroutine(WaitForDamage(_cooldown*0.4f));
            StartCoroutine(AttackCooldown());
            StartCoroutine(_aiAnimation.DoAttackAnimation((_cooldown-0.1f) * 0.85f));
        }
    }

    private IEnumerator WaitForDamage(float time)
    {
        yield return new WaitForSeconds(time);
        CharacterSelection.Instance.Characters[CharacterSelection.Instance.CharactersPlacement[0]].TakeDamage(_enemy.GetDamage());
        CharacterSelection.Instance.Characters[CharacterSelection.Instance.CharactersPlacement[1]].TakeDamage(_enemy.GetDamage());
    }

    private IEnumerator AttackCooldown()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_cooldown);
        _canAttack = true;
    }
}
