using System.Collections;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected float _originDamage = 0;
    protected float _damage = 0;

    protected float _cooldownAttack = 0;

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

    public float GetDamage()
    { return _damage; }

    public float GetCoolDownAttack() 
    { return _cooldownAttack;}
}
