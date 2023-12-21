public class TheMysteriousBeing : Enemy
{
    private void Awake()
    {
        MaxLife = 450;
        Life = MaxLife;

        _originDamage = 20;
        _damage = _originDamage;

        _cooldownAttack = 1;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
    }
}
