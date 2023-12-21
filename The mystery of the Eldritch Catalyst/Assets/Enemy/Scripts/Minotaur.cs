public class Minotaur : Enemy
{
    private void Awake()
    {
        MaxLife = 200;
        Life = MaxLife;

        _originDamage = 20;
        _damage = _originDamage;

        _cooldownAttack = 1.5f;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
        DropManager.Instance.DropItems(_dropPoint, "Minotaur");
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.MinotaurKilled);
    }
}
