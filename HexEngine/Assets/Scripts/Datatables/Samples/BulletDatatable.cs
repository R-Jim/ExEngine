public class BulletDatatable : Datatable
{
    public BulletDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            new DataSet(ModelPreset.Preset.Model, new string[]{"2", "2", "<action,0.CommonPropertySet.~Coordinate/>", "2", "", "0", "0", "0", "2" }),
        };
    }
}
