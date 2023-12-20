using UnityEngine;

public class Ruffian : Character
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

    [SerializeField] private float _distanceAction = 10;
    [SerializeField] private float _damageLight = 15;
    [SerializeField] private float _damageStrong = 30;
    private LayerMask _enemyLayer;

    [SerializeField] private GameObject _whiteSwoosh;
    [SerializeField] private GameObject _redSwoosh;

    [SerializeField] private GameObject _bloodParticle;

    private void Awake()
    {
        MaxLife = 125;
        Life = MaxLife;

        MaxStamina = 100;
        Stamina = 100;

        StaminaLoseActionOne = 25;
        StaminaLoseActionTwo = 30;

        ArmorMultiplier = 1.25f;
        StrengthMultiplier = 1.25f;
        MagicalMultiplier = 0;
        HealMultiplier = 1;

        _coolDownActionOne = 1;
        _coolDownActionTwo = 2;

        _enemyLayer = LayerMask.GetMask("Enemy");

        Name = "Ruffian";
        Forename = "Magnus Stormblade";
    }

    private void Start()
    {
        this.SetWeapon(Inventory.Instance.GetItemByName("Rusty Sword"));
        Inventory.Instance.RemoveItemByName("Rusty Sword");
    }

    public override void ActionOne()
    {
        if (_canActionOne && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionOne && !_isDead)
        {
            Instantiate(_whiteSwoosh, Camera.main.transform.position + transform.forward * 2, Quaternion.identity);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.NormalSwordAttack, 2);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceAction, _enemyLayer))
            {
                
                if (hitInfo.transform.CompareTag("Enemy"))
                {
                    hitInfo.transform.GetComponentInParent<Enemy>().TakeDamage(_damageLight);
                    Instantiate(_bloodParticle, hitInfo.transform.position, Quaternion.identity);
                    SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.KnifeStab, 1);
                }
            }

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionTwo && !_isDead)
        {
            Instantiate(_redSwoosh, Camera.main.transform.position + transform.forward * 2, Quaternion.identity);
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.HeavySwordAttack, 0.6f);
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _distanceAction))
            {
                if (hitInfo.transform.TryGetComponent(out Door door))
                {
                    door.BreakInteractable();
                }
                else if (hitInfo.transform.CompareTag("Enemy"))
                {
                    hitInfo.transform.GetComponentInParent<Enemy>().TakeDamage(_damageLight);
                    Instantiate(_bloodParticle, hitInfo.transform.position, Quaternion.identity);
                    SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.KnifeStab, 1);
                }
                else if (hitInfo.transform.TryGetComponent(out Chest chest))
                {
                    chest.BreakInteractable();
                    SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.SlammingDoor);
                }
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();
        }
    }
}
