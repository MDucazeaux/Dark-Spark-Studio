using System.Collections;
using UnityEngine;

public abstract class Enemy : Entity
{
    [SerializeField] private GameObject _poisonParticle;

    [SerializeField]
    protected Transform _dropPoint;
    protected float _originDamage = 0;
    protected float _damage = 0;

    protected float _cooldownAttack = 0;

    private Coroutine _poisonCoroutine = null;
    private float _waitPoison = 1;
    private float _allTimePoison = 10;
    private float _poisonDamage = 2;

    public void StartTransmutation()
    {
        StartCoroutine(Transmutation());
    }

    private IEnumerator Transmutation()
    {
        _damage -= _damage * 20 / 100;

        yield return new WaitForSeconds(_damage);

        _damage = _originDamage;
    }

    public void StartTakeDamageInTime()
    {
        if (_poisonCoroutine != null)
            StopCoroutine(_poisonCoroutine);

        _poisonCoroutine = StartCoroutine(TakeDamageInTime());
    }

    private IEnumerator TakeDamageInTime()
    {
        float _timePoison = 0;
        while (_timePoison < _allTimePoison)
        {
            TakeDamage(_poisonDamage, false);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.PoisonDamage, 0.3f);
            if (_poisonParticle)
            {
                Instantiate(_poisonParticle, transform.position, Quaternion.identity);
            }
            yield return new WaitForSeconds(_waitPoison);
            _timePoison += _waitPoison;
        }
    }

    public float GetDamage()
    { return _damage; }

    public float GetCoolDownAttack() 
    { return _cooldownAttack;}
}