public class Minotaur : Enemy
{
    private void Awake()
    {
        MaxLife = 200;
        Life = MaxLife;

        _originDamage = 30;
        _damage = _originDamage;
    }

    public override void Death()
    {

    }
}
