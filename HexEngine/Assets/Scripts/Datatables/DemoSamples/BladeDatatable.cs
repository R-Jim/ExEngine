public class BladeDatatable : ModelDatatable
{
    public BladeDatatable() : base(GetProperties(), null, GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            GetBlade(),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>"}),
            new DataSet(PropertyPreset.Preset.Damage, new string[]{"1", "1", "0" }),
        };
    }


    private static DataSet GetBlade()
    {
        string hp = "1";
        string weight = "1";
        return new DataSet(ModelPreset.Preset.Model, new string[] {
            hp,
            hp,
            "<in,0/>",
            weight,
            "host",
            "0",
            "0",
            "0",
            "<prop,1/>",
            "1", //TODO: change to Blade prefab
        });
    }

    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
        };
    }
}
