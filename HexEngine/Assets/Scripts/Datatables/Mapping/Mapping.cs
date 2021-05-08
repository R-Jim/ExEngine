using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Mapping
{
    private static readonly Regex SPECIAL = new Regex("<\\w*,~?\\d+(\\.~?\\w+)*\\/>");
    private static readonly Regex PROPERTY = new Regex("<prop,.*\\/>");
    private static readonly Regex INPUT_OR_ACTION = new Regex("<(in|action),.*\\/>");

    public static object MapProperty(Datatable datatable, Datatable.DataSet dataSet, object[] inputOrActionProperties)
    {
        List<object> convertedValue = GetConvertedList(datatable, dataSet, inputOrActionProperties);
        return MapPropertyWithPreset(dataSet.Preset, convertedValue.ToArray());
    }

    private static List<object> GetConvertedList(Datatable datatable, Datatable.DataSet dataSet, object[] inputOrActionProperties)
    {
        List<object> convertedValue = new List<object>();
        foreach (string value in dataSet.Values)
        {
            convertedValue.Add(GetConvertedValue(value, datatable, inputOrActionProperties));
        }
        return convertedValue;
    }

    private static object GetConvertedValue(string value, Datatable datatable, object[] inputOrActionProperties)
    {
        if (value == null)
        {
            return null;
        }
        if (SPECIAL.IsMatch(value))
        {
            return MapSpecialValue(datatable, value, inputOrActionProperties);
        }
        else
        {
            return RawValueMapper.GetValue(value);
        }
    }

    private static object MapSpecialValue(Datatable datatable, string value, object[] inputOrActionProperties)
    {
        string indexString = GetIndex(value, out string nestedFields);
        indexString = FormatString(indexString, out bool isClone);
        int index = int.Parse(indexString);
        object returnValue = null;
        try
        {
            if (PROPERTY.IsMatch(value))
            {
                returnValue = MapProperty(datatable, datatable.DataSets[index], inputOrActionProperties);
            }
            else if (INPUT_OR_ACTION.IsMatch(value))
            {
                returnValue = inputOrActionProperties[index];
            }

            if (isClone)
            {
                returnValue = CloneValue(value);
            }
            return GetNestedValue(returnValue, nestedFields);
        }
        catch (IndexOutOfRangeException e)
        {
            Debug.LogError("Index out of range on: " + value);
            throw e;
        }
    }

    private static object GetNestedValue(object value, string nestedString)
    {
        if (nestedString == null)
        {
            return value;
        }

        object returnValue = value;
        foreach (string field in nestedString.Split('.'))
        {
            returnValue = GetFieldValue(returnValue, FormatString(field, out bool isClone));
            if (isClone)
            {
                returnValue = CloneValue(returnValue);
            }
        }
        return returnValue;
    }

    private static object GetFieldValue(object dataObject, string field)
    {
        return dataObject.GetType().GetProperty(field).GetValue(dataObject, null);
    }

    private static object CloneValue(object value)
    {
        if (value is Coordinate coordinate)
        {
            return coordinate.Clone();
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
        isClone = false;
        return value;
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
        else if (preset is TriggerPreset.Preset)
        {
            return MapTriggerProperty((TriggerPreset.Preset)preset, mappedProperties);
        }
        else if (preset is DatatablePreset.Preset)
        {
            return MapDatatableProperty((DatatablePreset.Preset)preset, mappedProperties);
        }
        else if (preset is PropertyPreset.Preset)
        {
            return MapProperty((PropertyPreset.Preset)preset, mappedProperties);
        }
        return null;
    }

    private static object MapProperty(PropertyPreset.Preset preset, object[] mappedProperties)
    {
        return PropertyPreset.GetProperty(preset, mappedProperties);
    }

    private static object MapDatatableProperty(DatatablePreset.Preset preset, object[] mappedProperties)
    {
        Datatable datatable = DatatablePreset.GetDatatable(preset);
        return datatable.GetDataObject(mappedProperties);
    }

    private static Trigger MapTriggerProperty(TriggerPreset.Preset preset, object[] mappedProperties)
    {
        return TriggerPreset.GetTrigger(preset, mappedProperties);
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
