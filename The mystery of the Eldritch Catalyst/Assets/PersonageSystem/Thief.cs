using UnityEngine;

public class Thief : Character
{
    [SerializeField] private GameObject _knife;

    [SerializeField] private float _distanceActionTwo = 10;

    private LayerMask _chestLayer;
    private LayerMask _doorLayer;

    private void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;
        ArmorMultiplier = 1f;
        MaxStamina = 100;
        Stamina = 100;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;

        CoolDownActionOne = 1;
        CoolDownActionTwo = 1;

        _chestLayer = LayerMask.GetMask("Chest");
        _doorLayer = LayerMask.GetMask("Door");
    }

    public override void ActionOne()
    {
        if (_canActionOne)
        {
            Instantiate(_knife).GetComponent<Knife>().SetValues();

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
            else if (hitInfo.transform.TryGetComponent(out Chest chest))
            {
                chest.Unlock();
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
