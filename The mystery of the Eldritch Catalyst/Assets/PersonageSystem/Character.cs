using System.Collections;
using UnityEngine;

public abstract class Character : Entity
{
    protected string Name;
    protected string Forename;

    protected float MaxStamina;
    protected float Stamina;

    protected float StaminaLoseActionOne;
    protected float StaminaLoseActionTwo;

    protected float _coolDownActionOne;
    protected float _timeActionOne;
    protected float _coolDownActionTwo;
    protected float _timeActionTwo;

    protected bool _canActionOne = true;
    protected bool _canActionTwo = true;

    private bool _isProtected = false;
    private float _protectionTime = 3;

    protected bool _isDead = false;

    public abstract void ActionOne();
    public abstract void ActionTwo();

    public float GetStamina() 
    { return Stamina; }

    public float GetStaminaMax()
    { return MaxStamina; }

    public void Heal(float heal, float healMult)
    {
        Life = Mathf.Clamp(Life + heal * healMult, 0, MaxLife);
    }

    public void RecoverStamina(float stamina)
    {
        Stamina = Mathf.Clamp(Stamina + stamina, 0, MaxStamina);
    }

    public void UseStamina(float stamina)
    {
        Stamina = Mathf.Clamp(Stamina - stamina, 0, MaxStamina);
    }

    public override void TakeDamage(float damage)
    {
        if (Life > 0)
        {
            if (!_isProtected)
            {
                Life -= damage / ArmorMultiplier;
                Life = Life < 0 ? 0 : Life;

                CameraScript.Instance.TakeDamage();
            }

            if (Life <= 0)
                Death();
        }
    }

    public void StartCooldownActionOne()
    {
        StartCoroutine(CooldownActionOne());
    }

    private IEnumerator CooldownActionOne()
    {
        _canActionOne = false;

        while (_timeActionOne < CoolDownActionOne)
        {
            _timeActionOne += Time.deltaTime;
            yield return null;
        }

        _timeActionOne = 0;
        _canActionOne = true;
    }

    public void StartCooldownActionTwo()
    {
        StartCoroutine(CooldownActionTwo());
    }

    private IEnumerator CooldownActionTwo()
    {
        _canActionTwo = false;

        while (_timeActionTwo < CoolDownActionTwo)
        {
            _timeActionTwo += Time.deltaTime;
            yield return null;
        }

        _timeActionTwo = 0;
        _canActionTwo = true;
    }

    public void StartProtection()
    {
        StartCoroutine(Protection());
    }

    private IEnumerator Protection()
    {
        _isProtected = true;

        yield return new WaitForSeconds(_protectionTime);

        _isProtected = false;
    }

    public float GetHealMultiplier()
    { return HealMultiplier; }

    public string GetName()
    { return Name; }

    public override void Death()
    {
        _isDead = true;
        CharacterSelection.Instance.CharacterDeath(Name);

        NarratifManager.Instance.FeedBackCharacterDie(Forename);
    }

    public bool IsDead { get { return _isDead; } }
    public bool CanActionOne { get { return _canActionOne; } }
    public bool CanActionTwo { get { return _canActionTwo; } }
    public float TimeActionOne { get { return _timeActionOne; } }
    public float CoolDownActionOne { get { return _coolDownActionOne; } }
    public float TimeActionTwo { get { return _timeActionTwo; } }
    public float CoolDownActionTwo { get { return _coolDownActionTwo; } }
}
