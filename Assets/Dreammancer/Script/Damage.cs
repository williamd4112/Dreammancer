using UnityEngine;
using System.Collections;

public class Damage
{
    public enum DamageType
    {
        CRITICAL,
        NORMAL,
        NODAMAGE
    }

    public int DamageAmount;
    public DamageType Type;
    
    public Damage(int _damageAmount, DamageType _type)
    {
        this.DamageAmount = _damageAmount;
        this.Type = _type;
    }
}
