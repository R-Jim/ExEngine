public class ModelDatatable : Datatable
{
    public ActionSet[] ActionSets { get; }
    public ActionSet[] ExposedActionSets { get; }

    public ModelDatatable(DataSet[] properties, ActionSet[] actionSets, ActionSet[] exposedActionSets = null) : base(properties)
    {
        ActionSets = actionSets;
        ExposedActionSets = exposedActionSets;
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
