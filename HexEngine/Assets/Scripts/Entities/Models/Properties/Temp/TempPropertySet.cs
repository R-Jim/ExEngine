using System.Collections.Generic;

public class TempPropertySet
{
    private readonly Dictionary<string, int> TempPropertyDictionary = new Dictionary<string, int>();

    public void AddProperty(Set set)
    {
        if (!TempPropertyDictionary.ContainsKey(set.Type))
        {
            TempPropertyDictionary.Add(set.Type, set.Value);
        }
        else
        {
            TempPropertyDictionary[set.Type] += set.Value;
        }

        if (TempPropertyDictionary[set.Type] <= 0)
        {
            TempPropertyDictionary.Remove(set.Type);
        }
    }

    public Dictionary<string, int>.KeyCollection GetTypes()
    {
        return TempPropertyDictionary.Keys;
    }

    public bool HaveValue(string type)
    {
        return TempPropertyDictionary.ContainsKey(type);
    }

    public int GetValue(string type)
    {
        return TempPropertyDictionary[type];
    }

    public class Set
    {
        public string Type { get; }
        public int Value { get; }

        public Set(string type, int value)
        {
            Type = type;
            Value = value;
        }
    }
}
