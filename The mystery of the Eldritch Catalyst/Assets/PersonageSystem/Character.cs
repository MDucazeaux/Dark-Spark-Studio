using System.Collections;
using UnityEngine;
using UnityEngineInternal;

public abstract class Character : Entity
{
    protected string Name;
    protected string Forename;

    protected float MaxStamina;
    protected float Stamina;

    protected float StaminaLoseActionOne;
    protected float StaminaLoseActionTwo;

    protected float CoolDownActionOne;
    protected float CoolDownActionTwo;

    protected bool _canActionOne = true;
    protected bool _canActionTwo = true;

    private bool _isProtected = false;
    private float _protectionTime = 3;

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
        Stamina -= stamina;
    }

    public override void TakeDamage(float damage)
    {
        Life -= _isProtected ? damage / ArmorMultiplier : 0;
    }

    public void StartCooldownActionOne()
    {
        StartCoroutine(CooldownActionOne());
    }

    private IEnumerator CooldownActionOne()
    {
        _canActionOne = false;

        yield return new WaitForSeconds(CoolDownActionOne);

        _canActionOne = true;
    }

    public void StartCooldownActionTwo()
    {
        StartCoroutine(CooldownActionTwo());
    }

    private IEnumerator CooldownActionTwo()
    {
        _canActionTwo = false;

        yield return new WaitForSeconds(CoolDownActionTwo);

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
}
