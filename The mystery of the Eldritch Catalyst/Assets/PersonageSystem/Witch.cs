using UnityEngine;

public class Witch : Character
{
    [SerializeField] private GameObject _fireBall;

    private void Awake()
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

        CoolDownActionOne = 3;
        CoolDownActionTwo = 60;

        Name = "Witch";
    }

    public override void ActionOne()
    {
        if (_canActionOne)
        {
            Instantiate(_fireBall).GetComponent<FireBall>().SetValues(transform.position, transform.forward);

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo)
        {
            var AllCharacters = CharacterSelection.Instance.Characters;

            foreach (var character in AllCharacters.Values)
            {
                character.StartProtection();
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
