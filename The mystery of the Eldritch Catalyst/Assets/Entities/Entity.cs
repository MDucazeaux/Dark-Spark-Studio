using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected float MaxLife;
    protected float Life;

    protected float ArmorMultiplier = 1;
    protected float StrengthMultiplier = 1;
    protected float MagicalMultiplier = 1;
    protected float HealMultiplier = 1;

    protected ItemData _weapon;
    protected ItemData _armor;

    public float GetLife() 
    { return Life; }

    public float GetLifeMax()
    { return MaxLife; }

    public virtual void TakeDamage(float damage, bool doSound = true)
    {
        Life -= damage / ArmorMultiplier;
        if (doSound)
        {
            SoundsManager.Instance.PlaySFX(SoundsManager.TypesOfSFX.KnifeStab, 0.8f);
        }
        
        if (Life <= 0)
            Death();
    }

    // Armor
    public void AddArmorMultiplier(float number)
    { ArmorMultiplier += number; }

    public void ReduceArmorMultiplier(float number)
    { ArmorMultiplier -= number; }

    // Strenght
    public void AddStrenghtMultiplier(float number)
    { StrengthMultiplier += number; }

    public void ReduceStrenghtMultiplier(float number)
    { StrengthMultiplier -= number; }

    // Magical strenght
    public void AddMagicalStrenghtMultiplier(float number)
    { MagicalMultiplier += number; }

    public void ReduceMagicalStrenghtMultiplier(float number)
    { MagicalMultiplier -= number; }

    // Heal
    public void AddHealMultiplier(float number)
    { HealMultiplier += number; }

    public void ReduceHealMultiplier(float number)
    { HealMultiplier -= number; }

    public ItemData GetArmor()
    { return _armor; }

    public void SetArmor(ItemData armor)
    { _armor = armor; }

    public ItemData GetWeapon()
    { return _weapon; }

    public void SetWeapon(ItemData weapon)
    { _weapon = weapon; }

    public abstract void Death();
}
