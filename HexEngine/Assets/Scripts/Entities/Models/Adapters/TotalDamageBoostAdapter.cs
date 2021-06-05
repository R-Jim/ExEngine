using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TotalDamageBoostAdapter : IAdapter
{
    private static readonly string TYPE = "total_damage";
    private static readonly Regex TypeRegex = new Regex(TYPE + "_\\d");

    public Regex GetTypeRegex()
    {
        return TypeRegex;
    }

    public object Process(object input, Model model)
    {
        string[] types = GetTypes(model);
        if (types.Length == 0)
        {
            return input;
        }
        int total = 0;
        foreach (string type in types)
        {
            int modifier = int.Parse(type.Split('_')[1]);
            total += modifier * (int)input;
        }
        return total;
    }

    public string[] GetTypes(Model model)
    {
        List<string> typeList = new List<string>();
        foreach (string key in model.TempPropertySet.GetTypes())
        {
            if (TypeRegex.IsMatch(key))
            {
                typeList.Add(key);
            }
        }
        return typeList.ToArray();
    }

    public string buildTypeValue(object value)
    {
        return TYPE + "_" + value;
    }
}
