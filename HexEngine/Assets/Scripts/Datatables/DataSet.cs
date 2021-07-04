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
