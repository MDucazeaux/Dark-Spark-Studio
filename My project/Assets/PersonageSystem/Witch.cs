public class Witch : Character
{
    public override void Awake()
    {
        MaxLife = 75;
        Life = MaxLife;
        ArmorMultiplier = 1f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 0.75f;
        MagicalMultiplier = 1.25f;
        HealMultiplier = 1;
    }
}
