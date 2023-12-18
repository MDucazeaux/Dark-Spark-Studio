using UnityEngine;

public class Thief : Character
{
    [SerializeField] private GameObject _knife;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

    [SerializeField] private float _distanceActionTwo = 10;

    private LayerMask _chestLayer;
    private LayerMask _doorLayer;

    private void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;

        MaxStamina = 100;
        Stamina = 100;

        StaminaLoseActionOne = 10;
        StaminaLoseActionTwo = 5;

        ArmorMultiplier = 1f;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;

        _coolDownActionOne = 1;
        _coolDownActionTwo = 1;

        _chestLayer = LayerMask.GetMask("Chest");
        _doorLayer = LayerMask.GetMask("Door");

        Name = "Thief";
    }

    public override void ActionOne()
    {
        if (_canActionOne && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionOne && !_isDead)
        {
            Instantiate(_knife).GetComponent<Knife>().SetValues(transform.position, transform.forward);

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionTwo && !_isDead)
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
