public class Dullahan : Enemy
{
    private void Awake()
    {
        MaxLife = 300;
        Life = MaxLife;

        _originDamage = 10;
        _damage = _originDamage;

        _cooldownAttack = 2;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
        DropManager.Instance.DropItems(_dropPoint, "Dullahan");
        SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.DullahanKilled);
    }
}
