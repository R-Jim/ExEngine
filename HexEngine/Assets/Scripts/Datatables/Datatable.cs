public class Datatable
{
    public DataSet[] DataSets { get; }

    public Datatable(DataSet[] dataSets)
    {
        DataSets = dataSets;
    }

    public object GetDataObject(object[] inputProperties)
    {
        return Mapping.MapProperty(this, DataSets[0], inputProperties);
    }

    public class DataSet
    {
        public object Preset;
        public string[] Values;

        public DataSet(object preset, string[] values)
        {
            Preset = preset;
            Values = values;
        }
    }
}
