using UnityEngine;

public class Rat : Enemy
{
    private void Awake()
    {
        MaxLife = 50;
        Life = MaxLife;

        _originDamage = 5;
        _damage = _originDamage;

        _cooldownAttack = 1;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
        DropManager.Instance.DropItems(_dropPoint, "Rat");
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.RatKilled);
    }
}
