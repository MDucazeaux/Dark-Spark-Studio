public class Ruffian : Character
{
    public override void Awake()
    {
        MaxLife = 125;
        Life = MaxLife;
        ArmorMultiplier = 1.25f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 1.25f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;
    }

    public override void ActionOne()
    {

    }

    public override void ActionTwo()
    {

    }
}
