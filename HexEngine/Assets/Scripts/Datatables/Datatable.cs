public class Datatable
{
    public DataSet[] DataSets { get; }

    public Datatable(DataSet[] dataSets)
    {
        DataSets = dataSets;
    }

    public object GetDataValue(object[] inputProperties, int index = 0)
    {
        return Mapping.MapProperty(this, DataSets[index], inputProperties);
    }
}
