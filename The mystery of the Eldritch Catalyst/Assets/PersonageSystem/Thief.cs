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

        Name = "Thief";
        Forename = "Lila Nightshade";
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
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceActionTwo))
            {
                if (hitInfo.transform.TryGetComponent(out Door door))
                {
                    if (door.IsLocked && Inventory.Instance.IsInInventory("Lock Picking Tool"))
                    {
                        door.Unlock();
                        Inventory.Instance.RemoveItemByName("Lock Picking Tool");
                    }
                    else
                        NarratifManager.Instance.FeedBackNoLockpick();
                }
                else if (hitInfo.transform.TryGetComponent(out Chest chest))
                {
                    if (chest.IsLocked)
                    {
                        if (Inventory.Instance.IsInInventory("Lock Picking Tool"))
                        {
                            chest.Unlock();
                            Inventory.Instance.RemoveItemByName("Lock Picking Tool");
                        }
                        else
                            NarratifManager.Instance.FeedBackNoLockpick();
                    }
                }
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
