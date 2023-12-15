public class Dullahan : Enemy
{
    private void Awake()
    {
        MaxLife = 300;
        Life = MaxLife;

        _originDamage = 10;
        _damage = _originDamage;
    }

    public override void Death()
    {
        
    }
}
