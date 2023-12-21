public class TheMysteriousBeing : Enemy
{
    private void Awake()
    {
        MaxLife = 350;
        Life = MaxLife;

        _originDamage = 15;
        _damage = _originDamage;

        _cooldownAttack = 1;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
    }
}
