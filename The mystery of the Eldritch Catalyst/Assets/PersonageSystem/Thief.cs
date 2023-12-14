using UnityEngine;

public class Thief : Character
{
    [SerializeField] private GameObject _knife;

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

    public override void ActionOne()
    {
        GameObject.Instantiate(_knife).GetComponent<Knife>().SetValues();

        UseStamina(StaminaLoseActionOne);

        StartCooldownActionOne();
    }

    public override void ActionTwo()
    {
        
    }
}
