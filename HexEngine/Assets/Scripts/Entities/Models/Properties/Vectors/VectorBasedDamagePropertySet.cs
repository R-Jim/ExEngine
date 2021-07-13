using System.Collections.Generic;

public class VectorBasedDamagePropertySet : IVectorBasedPropertySet
{
    private readonly Dictionary<Coordinate.Vector, DamagePropertySet> VectorBasedDictionary = new Dictionary<Coordinate.Vector, DamagePropertySet>();

    public VectorBasedDamagePropertySet()
    {

    }

    public void AddValue(Coordinate.Vector vector, object value)
    {
        if (value is DamagePropertySet)
        {
            DamagePropertySet damagePropertySet = (DamagePropertySet)value;

            if (VectorBasedDictionary.TryGetValue(vector, out DamagePropertySet valueInDictionary))
            {
                VectorBasedDictionary[vector] = new DamagePropertySet(
                        damagePropertySet.Value + valueInDictionary.Value,
                        damagePropertySet.ImpactValueModifier + valueInDictionary.ImpactValueModifier
                    );
            }
            else
            {
                VectorBasedDictionary.Add(vector, damagePropertySet);
            }
        }
    }

    public object GetValue(Coordinate.Vector vector)
    {
        return VectorBasedDictionary.TryGetValue(vector, out DamagePropertySet value) ? value : new DamagePropertySet(0, 0);
    }
}
