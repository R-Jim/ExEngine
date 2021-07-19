using System;

public class DamagePropertySet
{
    public int Value { get; }
    public float ImpactValueModifier { get; }

    public DamagePropertySet(int baseValue, float impactValueModifier = 1)
    {
        Value = baseValue;
        ImpactValueModifier = impactValueModifier;
    }

    public int GetDamageValue(float impactValue)
    {
        return Value + (int)Math.Ceiling(impactValue * ImpactValueModifier);
    }

    public bool IsEmpty()
    {
        return Value == 0 && ImpactValueModifier == 0;
    }
}
