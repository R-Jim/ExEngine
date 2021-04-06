public class DummyDatatable : Datatable
{
    public DummyDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            // Dummy body
            new DataSet(ModelPreset.Preset.Model, new string[]{"10", "10", "<action,0/>", "2", "Dummy", "0", "0", "0", "<prop,1/>", "3", "<prop,3/>" }),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>" }),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"0.1", "1" }),

            new DataSet(PropertyPreset.Preset.MountArray, new string[]{"<prop,4/>" }),
            new DataSet(PropertyPreset.Preset.Mount, new string[]{null, "Head", "<action,0/>", "<prop,5/>" }),

            // Dummy head
            new DataSet(ModelPreset.Preset.Model, new string[]{"5", "5", "<action,0/>", "2", "Head", "0", "0", "0", "<prop,6/>", "2" }),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,7/>" }),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"1.0", "1" })
        };
    }
}
