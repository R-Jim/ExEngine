using System;

public class DamagePropertySet
{
    public int Value { get; }
    public float ImpactValueModifier { get; }
    public bool IsTrueDamage { get; }

    public DamagePropertySet(int baseValue, float impactValueModifier, bool isTrueDamage)
    {
        Value = baseValue;
        ImpactValueModifier = impactValueModifier;
        IsTrueDamage = isTrueDamage;
    }

    public int GetDamageValue(float impactValue)
    {
        return Value + (int)Math.Ceiling(impactValue * ImpactValueModifier);
    }
}
