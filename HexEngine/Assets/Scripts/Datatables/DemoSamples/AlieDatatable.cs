public class AlieDatatable : ModelDatatable
{
    public AlieDatatable() : base(GetProperties(), GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init Alie
            GetAlie(),
            //
            new DataSet(PropertyPreset.Preset.CombatProperty, new string[]{"<prop,2/>"}),
            new DataSet(PropertyPreset.Preset.Armor, new string[]{"0", "1", "1" }),
            //TODO: command move
        };
    }

    private static DataSet GetAlie()
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
            "1", //TODO: change to Alie prefab
        }); 
    }


    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
        };
    }
}
