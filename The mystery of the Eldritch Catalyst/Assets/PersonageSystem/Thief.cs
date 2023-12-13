public class Thief : Character
{
    public override void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;
        ArmorMultiplier = 1f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;
    }
}
