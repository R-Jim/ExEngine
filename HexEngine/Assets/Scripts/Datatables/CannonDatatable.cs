public class CannonDatatable : ModelDatatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet(ModelPreset.Preset.Storage, new string[]{"10", "100", "100", "<in,0/>", "10", "weapon", "0", "0", "0", "1" }), //Usage index 0
            new DataSet(ModelPreset.Preset.Model, new string[]{"2", "2", "<action,0/>", "2", "", "0", "0", "0", "2" }), //Usage index 1
            //Spawn projectile
            new DataSet(TriggerPreset.Preset.Request, new string[]{ "<action,0/>", "1", "1"}),
            new DataSet(TriggerPreset.Preset.Spawn, new string[]{ "<action,0/>", "<action,2/>",  "0"}),
            new DataSet(TriggerPreset.Preset.Chain, new string[]{ "<action,0/>", "<prop,2/>", "<prop,3/>", "0"}), //Usage index 4
            new DataSet(EffectPreset.Preset.Modifier, new string[]{ "2", "<action,1/>", "5" }),
            new DataSet(TriggerPreset.Preset.Target, new string[]{ "<action,2/>", "<action,2/>", "<prop,5/>", "0"}), //Usage index 6
            new DataSet(TriggerPreset.Preset.Chain, new string[]{ "<action,0/>", "<prop,4/>", "<prop,6/>", "0"}), //Usage index 7
            //Move cannon
            new DataSet(EffectPreset.Preset.Modifier, new string[]{ "2", "<action,0/>", "1"  }),
            new DataSet(TriggerPreset.Preset.Target, new string[]{ "<action,0/>", "<init,0/>", "<prop,8/>", "0"}), //Usage index 9
            //
            new DataSet(PropertyPreset.Preset.Coordinate, new string[]{ "<action,0.Coordinate/>" })
        };
    }


    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
            new ActionSet(1, 7),
            new ActionSet(2, 9),
        };
    }
}
