using System.Collections;
using UnityEngine;

public abstract class Enemy : Entity
{
    protected float _originDamage = 0;
    protected float _damage = 0;

    public abstract void Attack();

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
}
