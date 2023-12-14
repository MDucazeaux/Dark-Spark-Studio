using UnityEngine;

public class Witch : Character
{
    [SerializeField] private GameObject _fireBall;

    public override void Awake()
    {
        MaxLife = 75;
        Life = MaxLife;
        ArmorMultiplier = 1f;
        MaxStamina = 100;
        Stamina = 100;
        StaminaLoseActionOne = 10;
        StaminaLoseActionTwo = 60;
        StrengthMultiplier = 0.75f;
        MagicalMultiplier = 1.25f;
        HealMultiplier = 1;
    }

    public override void ActionOne()
    {
        GameObject.Instantiate(_fireBall).GetComponent<FireBall>().SetValues();

        UseStamina(StaminaLoseActionOne);

        StartCooldownActionOne();
    }

    public override void ActionTwo()
    {

    }
}
