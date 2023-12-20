using UnityEngine;

public class Alchemist : Character
{
    [SerializeField] private GameObject _potion;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

    [SerializeField] private float _distanceActionTwo = 10;

    private LayerMask _enemyLayer;

    [SerializeField] private GameObject _transmutationSpellVisual;

    private void Awake()
    {
        MaxLife = 100;
        Life = MaxLife;

        MaxStamina = 100;
        Stamina = MaxStamina;

        StaminaLoseActionOne = 25;
        StaminaLoseActionTwo = 30;

        ArmorMultiplier = 1f;
        StrengthMultiplier = 1f;
        MagicalMultiplier = 0;
        HealMultiplier = 1.25f;

        _coolDownActionOne = 1;
        _coolDownActionTwo = 30;

        _enemyLayer = LayerMask.GetMask("Enemy");

        Name = "Alchemist";
        Forename = "Thaddeus Emberstone";
    }

    public override void ActionOne()
    {
        if (_canActionOne && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionOne && !_isDead)
        {
            Instantiate(_potion).GetComponent<PoisonedPotion>().SetValues(transform.position, transform.forward);

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();

            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.PotionThrowing);
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionTwo && !_isDead)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceActionTwo, _enemyLayer))
            {
                hitInfo.transform.GetComponentInParent<Enemy>().StartTransmutation();
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();

            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.TransmutationSpell, 0.6f);

            Instantiate(_transmutationSpellVisual, _transmutationSpellVisual.transform.position, transform.rotation);
        }
    }
}
