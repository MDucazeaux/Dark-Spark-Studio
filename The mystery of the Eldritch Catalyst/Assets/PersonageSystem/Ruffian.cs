using UnityEngine;

public class Ruffian : Character
{
    [SerializeField] private float _distanceActionTwo = 10;
    [SerializeField] private float _damageLight = 15;
    [SerializeField] private float _damageStrong = 30;
    private LayerMask _enemyLayer;

    private void Awake()
    {
        MaxLife = 125;
        Life = MaxLife;
        ArmorMultiplier = 1.25f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 1.25f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;

        CoolDownActionOne = 1;
        CoolDownActionTwo = 2;

        _enemyLayer = LayerMask.GetMask("Enemy");
    }

    public override void ActionOne()
    {
        if (_canActionOne)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceActionTwo, _enemyLayer))
            {
                if (hitInfo.transform.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(_damageLight);
                }
            }

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo)
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceActionTwo);

            if (hitInfo.transform.TryGetComponent(out Door door))
            {
                door.Unlock();
            }
            else if (hitInfo.transform.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(_damageStrong);
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
