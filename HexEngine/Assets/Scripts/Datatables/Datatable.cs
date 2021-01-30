using System.Collections.Generic;

public class Datatable
{
    public DataSet[] Properties { get; }
    public object[] InitialedProperties { get; private set; }
    public EffectActionSet[] EffectActions { get; }
    private readonly int MainPropertyIndex;
    public int[] InitProperties { get; }

    public Datatable(DataSet[] properties, EffectActionSet[] effectActions, int[] initProperties, int mainPropertyIndex)
    {
        Properties = properties;
        EffectActions = effectActions;
        MainPropertyIndex = mainPropertyIndex;
        InitProperties = initProperties;
    }

    public void Init(object[] inputProperties)
    {
        List<object> initialedList = new List<object>();
        foreach (int index in InitProperties)
        {
            initialedList.Add(Mapping.MapProperty(this, index, inputProperties));
            InitialedProperties = initialedList.ToArray();
        }
    }

    public List<Trigger> GetTriggerListByAction(int actionKey, object[] actionProperties)
    {
        List<Trigger> triggerList = new List<Trigger>();
        foreach (EffectActionSet effectActionSet in EffectActions)
        {
            if (effectActionSet.ActionKey == actionKey)
            {

                triggerList.Add(
                    (Trigger) Mapping.MapProperty(
                        this, effectActionSet.PropertyIndex, GetPropertyList(effectActionSet, actionProperties).ToArray()
                        ));
            }
        }
        return triggerList;
    }

    public List<object> GetPropertyList(EffectActionSet effectActionSet, object[] actionProperties)
    {
        List<object> initialedList = new List<object>();
        initialedList.AddRange(actionProperties);
        foreach (int index in effectActionSet.InitProperties)
        {
            initialedList.Add(Mapping.MapProperty(this, index, actionProperties));
        }
        return initialedList;
    }

    public object MainProperty()
    {
        return InitialedProperties[MainPropertyIndex];
    }

    public DataSet GetMainDataSet()
    {
        return Properties[MainPropertyIndex];
    }

    public class DataSet
    {
        public string PresetString;
        public string[] Values;

        public DataSet(string presetString, string[] values)
        {
            PresetString = presetString;
            Values = values;
        }
    }

    public class EffectActionSet
    {
        public int ActionKey;
        public int[] InitProperties;
        public int PropertyIndex;

        public EffectActionSet(int actionKey, int[] initProperties, int propertyIndex)
        {
            ActionKey = actionKey;
            InitProperties = initProperties;
            PropertyIndex = propertyIndex;
        }
    }
}
