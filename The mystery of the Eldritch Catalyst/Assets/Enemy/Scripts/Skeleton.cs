public class Skeleton : Enemy
{
    private void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;

        _originDamage = 20;
        _damage = _originDamage;
    }

    public override void Death()
    {

    }
}
