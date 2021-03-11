using System.Collections.Generic;

public class ModelDatatable : Datatable
{
    public ActionSet[] ActionSets { get; }

    public ModelDatatable(DataSet[] properties, ActionSet[] actionSets) : base(properties)
    {
        ActionSets = actionSets;
    }

    public List<Trigger> GetTriggerListByAction(int actionKey)
    {
        List<Trigger> triggerList = new List<Trigger>();
        foreach (ActionSet actionSet in ActionSets)
        {
            if (actionSet.Key == actionKey)
            {

                triggerList.Add((Trigger)Mapping.MapProperty(this, DataSets[actionSet.PropertyIndex], new object[0]));
            }
        }
        return triggerList;
    }

    public class ActionSet
    {
        public int Key { get; }
        public int PropertyIndex { get; }

        public ActionSet(int key, int propertyIndex)
        {
            Key = key;
            PropertyIndex = propertyIndex;
        }
    }
}
