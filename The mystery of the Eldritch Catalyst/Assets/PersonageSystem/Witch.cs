public class Witch : Character
{
    private void Awake()
    {
        Life = 75;
        ArmorMultiplier = 1f;
        Stamina = 100;
        StrengthMultiplier = 0.75f;
        MagicalMultiplier = 1.25f;
        HealMultiplier = 1;
    }
}
