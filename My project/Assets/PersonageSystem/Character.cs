using UnityEngine;

public abstract class Character : MonoBehaviour
{
    protected float Life;
    protected float Stamina;
    protected string Name;
    protected string Forename;
    protected float ArmorMultiplier;
    protected float StrengthMultiplier;
    protected float MagicalMultiplier;
    protected float HealMultiplier;

    public void Attack()
    {
    }

    public float GetLife()
    {
        return Life;
    }

    public float GetStamina()
    {
        return Stamina;
    }

    public void Heal(float heal)
    {
        Life += heal * HealMultiplier;
    }

    public void RecoverStamina(float stamina)
    {
        Stamina += stamina;
    }

    public void TakeDamage(float damage)
    {
        Life -= damage / ArmorMultiplier;
    }

    public void UseStamina(float stamina)
    {
        Stamina -= stamina;
    }
}
