using System.Collections.Generic;

class Host
{
    public ModelDatatable ModelDatatable { get; }
    public Model Model { get; }

    public Host(ModelDatatable modelDatatable, object[] inputProperties)
    {
        ModelDatatable = modelDatatable;
        Model = (Model)modelDatatable.GetDataObject(inputProperties);
    }

    public List<Trigger> GetTriggerListByAction(int actionKey)
    {
        List<Trigger> triggerList = new List<Trigger>();
        foreach (ModelDatatable.ActionSet actionSet in ModelDatatable.ActionSets)
        {
            if (actionSet.Key == actionKey)
            {
                triggerList.Add((Trigger)Mapping.MapProperty(ModelDatatable, ModelDatatable.DataSets[actionSet.PropertyIndex], new object[] { Model }));
            }
        }
        return triggerList;
    }
}
