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

    public virtual void TakeDamage(float damage)
    {
        Life -= damage / ArmorMultiplier;

        if (Life <= 0)
            Death();
    }

    public void SetArmorMultiplier(float number)
    { ArmorMultiplier = number; }

    public void SetStrenghtMultiplier(float number)
    { StrengthMultiplier = number; }

    public void SetMagicalStrenghtMultiplier(float number)
    { MagicalMultiplier = number; }

    public void SetHealMultiplier(float number)
    { HealMultiplier = number; }

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
