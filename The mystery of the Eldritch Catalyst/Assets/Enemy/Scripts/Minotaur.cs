public class Minotaur : Enemy
{
    private void Awake()
    {
        MaxLife = 200;
        Life = MaxLife;

        _originDamage = 30;
        _damage = _originDamage;

        _cooldownAttack = 1.5f;
    }

    public override void Death()
    {
        GetComponent<AIController>().Death();
    }
}
