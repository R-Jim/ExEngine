using System;
using System.Collections.Generic;

public class DamagePropertySet
{
    private readonly Dictionary<Coordinate.Vector, DamageProperty> VectorBasedDictionary = new Dictionary<Coordinate.Vector, DamageProperty>();

    public DamagePropertySet(DamageProperty[] damageProperties)
    {
        for (int i = 0; i < damageProperties.Length; i++)
        {
            VectorBasedDictionary.Add((Coordinate.Vector)i, damageProperties[i]);
        }
    }

    public DamageProperty GetValue(Coordinate.Vector vector)
    {
        return VectorBasedDictionary.TryGetValue(vector, out DamageProperty damageProperty) ? damageProperty : new DamageProperty(0, 0);
    }

    public class DamageProperty
    {
        public int Value { get; }
        public float ImpactValueModifier { get; }

        public DamageProperty(int baseValue, float impactValueModifier)
        {
            Value = baseValue;
            ImpactValueModifier = impactValueModifier;
        }

        public int GetDamageValue(float impactValue)
        {
            return Value + (int)Math.Ceiling(impactValue * ImpactValueModifier);
        }
    }
}
