using UnityEngine;

public abstract class Character
{
    protected float MaxLife;
    protected float Life;
    protected float MaxStamina;
    protected float Stamina;
    protected string Name;
    protected string Forename;
    protected float ArmorMultiplier;
    protected float StrengthMultiplier;
    protected float MagicalMultiplier;
    protected float HealMultiplier;
    private ItemData _weapon;
    private ItemData _armor;

    public abstract void Awake();

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

    public void Heal(float heal, float healMult)
    {
        
        Life = Mathf.Clamp(Life + heal * healMult, 0, MaxLife);
    }

    public void RecoverStamina(float stamina)
    {
        Stamina = Mathf.Clamp(Stamina + stamina, 0, MaxStamina);
    }

    public void TakeDamage(float damage)
    {
        Life -= damage / ArmorMultiplier;
    }

    public void UseStamina(float stamina)
    {
        Stamina -= stamina;
    }

    public float GetHealMultiplier { get { return HealMultiplier; } }
    public float GetLifeMax { get { return MaxLife;  } }

    public float GetStaminaMax { get { return MaxStamina; } }
    
    public ItemData GetArmor()
    {
         return _armor; 
    }
    
    public void SetArmor(ItemData armor) 
    {
        _armor = armor;
    }
    
    public ItemData GetWeapon()
    {
        return _weapon;
    }
    
    public void SetWeapon(ItemData weapon) 
    {
        _weapon = weapon;
    }
}
