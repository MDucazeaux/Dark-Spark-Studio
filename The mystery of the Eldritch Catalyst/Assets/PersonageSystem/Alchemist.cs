using UnityEngine;

public class Alchemist : Character
{
    [SerializeField] private GameObject _potion;

    public override void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;
        ArmorMultiplier = 1f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1.25f;
    }

    public override void ActionOne()
    {
        GameObject.Instantiate(_potion).GetComponent<PoisonedPotion>().SetValues();

        UseStamina(StaminaLoseActionOne);

        StartCooldownActionOne();
    }

    public override void ActionTwo()
    {
        
    }
}
