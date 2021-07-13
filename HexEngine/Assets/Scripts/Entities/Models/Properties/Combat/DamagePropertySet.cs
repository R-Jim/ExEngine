using System;

public class DamagePropertySet
{
    //private readonly Dictionary<Coordinate.Vector, DamageProperty> VectorBasedDictionary = new Dictionary<Coordinate.Vector, DamageProperty>();
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

    //public DamagePropertySet(DamageProperty[] damageProperties)
    //{
    //    for (int i = 0; i < damageProperties.Length; i++)
    //    {
    //        VectorBasedDictionary.Add((Coordinate.Vector)i, damageProperties[i]);
    //    }
    //}

    //public DamageProperty GetValue(Coordinate.Vector vector)
    //{
    //    return VectorBasedDictionary.TryGetValue(vector, out DamageProperty damageProperty) ? damageProperty : new DamageProperty(0, 0);
    //}
}
