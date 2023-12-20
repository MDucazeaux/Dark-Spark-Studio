using UnityEngine;

public class Witch : Character
{
    [SerializeField] private GameObject _fireBall;

    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerRotation _playerRotation;

    private void Awake()
    {
        MaxLife = 75;
        Life = MaxLife;

        MaxStamina = 100;
        Stamina = 100;

        StaminaLoseActionOne = 10;
        StaminaLoseActionTwo = 30;

        ArmorMultiplier = 1f;
        StrengthMultiplier = 0.75f;
        MagicalMultiplier = 1.25f;
        HealMultiplier = 1;

        _coolDownActionOne = 3;
        _coolDownActionTwo = 60;

        Name = "Witch";
        Forename = "Elara Moonfire";
    }

    public override void ActionOne()
    {
        if (_canActionOne && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionOne && !_isDead)
        {
            Instantiate(_fireBall).GetComponent<FireBall>().SetValues(transform.position, transform.forward);

            UseStamina(StaminaLoseActionOne);

            StartCooldownActionOne();

            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.FireBallSpell, 0.3f);
        }
    }

    public override void ActionTwo()
    {
        if (_canActionTwo && !_playerMovement.IsMoving && !_playerRotation.IsRotating && Stamina >= StaminaLoseActionTwo && !_isDead)
        {
            var AllCharacters = CharacterSelection.Instance.Characters;

            foreach (var character in AllCharacters.Values)
            {
                character.StartProtection();
            }

            UseStamina(StaminaLoseActionTwo);

            StartCooldownActionTwo();

            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.InvincibilitySpell);
        }
    }
}
