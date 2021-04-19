public class BulletDatatable : Datatable
{
    public BulletDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            new DataSet(ModelPreset.Preset.Model, new string[]{"2", "2", "<action,0/>", "2", "bullet", "0", "0", "0", "<prop,1/>", "2" }),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>", "<prop,3/>", "<prop,4/>" }),
            new DataSet(PropertyPreset.Preset.Damage, new string[]{"-2", "0.0", "false" }),
            new DataSet(PropertyPreset.Preset.Damage, new string[]{"-1", "0.0", "true" }),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"0.5", "1" }),
        };
    }
}
