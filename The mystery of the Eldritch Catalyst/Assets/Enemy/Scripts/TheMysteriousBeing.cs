public class TheMysteriousBeing : Enemy
{
    private void Awake()
    {
        MaxLife = 250;
        Life = MaxLife;

        _originDamage = 25;
        _damage = _originDamage;
    }

    public override void Death()
    {

    }
}
