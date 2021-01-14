using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Mapping
{
    private static readonly Regex SpecialSyntaxRegex = new Regex("<\\w*,~?\\d+(\\.~?\\w+)*\\/>");
    private static readonly Regex PropSyntaxRegex = new Regex("<prop,.*\\/>");
    private static readonly Regex InitSyntaxRegex = new Regex("<init,.*\\/>");
    private static readonly Regex InputOrActionSyntaxRegex = new Regex("<(in|action),.*\\/>");

    public static object MapProperty(Datatable datatable, int index, object[] inputOrActionProperties)
    {
        Datatable.DataSet dataSet = datatable.Properties[index];

        List<object> convertedValue = new List<object>();
        foreach (string value in dataSet.Values)
        {
            if (SpecialSyntaxRegex.IsMatch(value))
            {
                convertedValue.Add(MapSpecialValue(datatable, value, inputOrActionProperties));
            }
            else
            {
                convertedValue.Add(GetRawValue(value));
            }
        }

        object preset = PresetConverter.GetPreset(dataSet.PresetString);
        return MapPropertyWithPreset(preset, convertedValue.ToArray());
    }

    private static object MapSpecialValue(Datatable datatable, string value, object[] inputOrActionProperties)
    {
        string indexString = GetIndex(value, out string nestedFields);
        indexString = FormatString(indexString, out bool isClone);
        int index = int.Parse(indexString);
        object returnValue = null;
        if (PropSyntaxRegex.IsMatch(value))
        {
            returnValue = MapProperty(datatable, index, inputOrActionProperties);
        }
        else if (InitSyntaxRegex.IsMatch(value))
        {
            returnValue = datatable.InitialedProperties[index];
        }
        else if (InputOrActionSyntaxRegex.IsMatch(value))
        {
            returnValue = inputOrActionProperties[index];
        }

        if (isClone)
        {
            returnValue = CloneValue(value);
        }
        return GetNestedValue(returnValue, nestedFields);
    }

    private static object GetNestedValue(object value, string nestedString)
    {
        object returnValue = value;
        if (nestedString == null)
        {
            return returnValue;
        }
        string[] nestedFields = nestedString.Split('.');
        foreach (string field in nestedFields)
        {
            string formatedField = FormatString(field, out bool isClone);
            returnValue = returnValue.GetType().GetProperty(formatedField).GetValue(returnValue, null);
            if (isClone)
            {
                returnValue = CloneValue(returnValue);
            }
        }
        return returnValue;
    }

    private static object CloneValue(object value)
    {
        if (value is Effect)
        {
            return ((Effect)value).Clone();
        }
        else if (value is Coordinate)
        {
            return ((Coordinate)value).Clone();
        }
        return value;
    }

    private static string GetIndex(string value, out string nestedFields)
    {
        string[] sections = value.Substring(1, value.Length - 3).Split(',');
        string index = sections[1];
        nestedFields = null;
        if (index.Contains("."))
        {
            nestedFields = index.Substring(index.IndexOf(".") + 1);
            index = index.Substring(0, index.IndexOf("."));
        }
        return index;
    }

    private static string FormatString(string value, out bool isClone)
    {
        if (value.Contains("~"))
        {
            isClone = true;
            return value.Replace("~", "");
        }
        else
        {
            isClone = false;
            return value;
        }
    }

    private static object GetRawValue(string value)
    {
        try
        {
            return int.Parse(value);
        }
        catch (FormatException)
        {
            return value;
        }
    }

    private static object MapPropertyWithPreset(object preset, object[] mappedProperties)
    {
        if (preset is ModelPreset.Preset)
        {
            return MapModelProperty((ModelPreset.Preset)preset, mappedProperties);
        }
        else if (preset is EffectPreset.Preset)
        {
            return MapEffectProperty((EffectPreset.Preset)preset, mappedProperties);
        }
        return null;
    }

    private static Effect MapEffectProperty(EffectPreset.Preset preset, object[] mappedProperties)
    {
        return EffectPreset.GetEffect(preset, mappedProperties);
    }

    private static Model MapModelProperty(ModelPreset.Preset preset, object[] mappedProperties)
    {
        return ModelPreset.GetModel(preset, mappedProperties);
    }
}
