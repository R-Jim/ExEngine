using System.Collections.Generic;

public class VectorBasedIntPropertySet : IVectorBasedPropertySet
{
    private readonly Dictionary<Coordinate.Vector, int> VectorBasedDictionary = new Dictionary<Coordinate.Vector, int>();

    public VectorBasedIntPropertySet()
    {

    }

    public void AddValue(Coordinate.Vector vector, object value)
    {
        if (value is int)
        {
            if (VectorBasedDictionary.TryGetValue(vector, out int valueInDictionary))
            {
                VectorBasedDictionary[vector] = (int)value + valueInDictionary;
            }
            else
            {
                VectorBasedDictionary.Add(vector, (int)value);
            }
        }
    }

    public object GetValue(Coordinate.Vector vector)
    {
        return VectorBasedDictionary.TryGetValue(vector, out int value) ? value : 0;
    }
}
