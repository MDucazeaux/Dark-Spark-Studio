public class Alchemist : Character
{
    private void Awake()
    {
        Life = 100;
        ArmorMultiplier = 1f;
        Stamina = 100;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1.25f;
    }
}
