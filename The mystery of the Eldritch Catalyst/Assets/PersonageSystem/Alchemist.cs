using UnityEngine;

public class Alchemist : Character
{
    [SerializeField] private GameObject _potion;

    [SerializeField] private float _distanceActionTwo = 10;

    private LayerMask _enemyLayer;

    private void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;
        MaxStamina = 100;
        Stamina = MaxStamina;

        ArmorMultiplier = 1f;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1.25f;

        CoolDownActionOne = 1;
        CoolDownActionTwo = 30;

        _enemyLayer = LayerMask.GetMask("Enemy");
    }

    public override void ActionOne()
    {
        if (_canActionOne)
        {
            Instantiate(_potion).GetComponent<PoisonedPotion>().SetValues(transform.position, transform.forward);

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceActionTwo, _enemyLayer))
            {
                hitInfo.transform.GetComponent<Enemy>().StartTransmutation();
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
