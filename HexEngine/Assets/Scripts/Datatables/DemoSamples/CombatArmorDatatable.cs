public class CombatArmorDatatable : ModelDatatable
{
    public CombatArmorDatatable() : base(GetProperties(), null, GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            GetArmor(),
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>"}),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"1", "1", "1" }),
        };
    }

    private static DataSet GetArmor()
    {
        string hp = "3";
        string weight = "0";
        return new DataSet(ModelPreset.Preset.Model, new string[] {
            hp,
            hp,
            "<action,0/>",
            weight,
            "armor",
            "0",
            "0",
            "0",
            "<prop,1/>",
            "2", //TODO change to Armor prefab
        });
    }

    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
        };
    }
}
