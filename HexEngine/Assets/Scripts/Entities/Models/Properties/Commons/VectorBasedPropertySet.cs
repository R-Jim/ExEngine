using System.Collections.Generic;

public class VectorBasedPropertySet
{
    private readonly Dictionary<Coordinate.Vector, int> VectorBasedDictionary = new Dictionary<Coordinate.Vector, int>();

    public VectorBasedPropertySet()
    {

    }

    public void AddValue(Coordinate.Vector vector, int value)
    {
        if (VectorBasedDictionary.TryGetValue(vector, out int valueInDictionary))
        {
            VectorBasedDictionary[vector] = value + valueInDictionary;
        }
        else
        {
            VectorBasedDictionary.Add(vector, value);
        }
    }

    public int GetValue(Coordinate.Vector vector)
    {
        return VectorBasedDictionary.TryGetValue(vector, out int value) ? value : 0;
    }
}
