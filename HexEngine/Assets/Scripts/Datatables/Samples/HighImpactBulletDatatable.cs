public class HighImpactBulletDatatable : Datatable
{
    public HighImpactBulletDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            new DataSet(ModelPreset.Preset.Model, new string[]{"2", "2", "<action,0/>", "2", "HI-bullet", "0", "0", "0", "<prop,1/>", "2" }),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>", "<prop,3/>" }),
            new DataSet(PropertyPreset.Preset.Damage, new string[]{"0", "-10.0", "false" }),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"0.2", "1" }),
        };
    }
}
