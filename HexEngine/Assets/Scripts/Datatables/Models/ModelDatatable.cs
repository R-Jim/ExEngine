public class ModelDatatable : Datatable
{
    public ActionSet[] ActionSets { get; }

    public ModelDatatable(DataSet[] properties, ActionSet[] actionSets) : base(properties)
    {
        ActionSets = actionSets;
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
