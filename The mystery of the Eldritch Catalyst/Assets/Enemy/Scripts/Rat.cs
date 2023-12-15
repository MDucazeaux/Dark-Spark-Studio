using UnityEngine;

public class Rat : Enemy
{
    private void Awake()
    {
        MaxLife = 50;
        Life = MaxLife;

        _originDamage = 10;
        _damage = _originDamage;

        _cooldownAttack = 1;
    }

    public override void Death()
    {

    }
}
