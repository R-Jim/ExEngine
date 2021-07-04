public class FiringBulletDatatable : Datatable
{
    public FiringBulletDatatable() : base(GetProperties())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            new DataSet(TriggerPreset.Preset.Chain, new string[]{ "<action,0/>", "<prop,3/>", "<prop,5/>", "0"}),
            //Spawn projectile
            new DataSet(TriggerPreset.Preset.Request, new string[]{ "<action,0/>", "ammo", "1", "1"}),
            new DataSet(TriggerPreset.Preset.Spawn, new string[]{ "<action,0/>", "<action,1/>",  "0"}),
            new DataSet(TriggerPreset.Preset.Chain, new string[]{ "<action,0/>", "<prop,1/>", "<prop,2/>", "0"}), //Usage index 3
            new DataSet(EffectPreset.Preset.Modifier, new string[]{ "2", "<action,2/>", "5" }),
            new DataSet(TriggerPreset.Preset.Target, new string[]{ "<action,1/>", "<action,1/>", "<prop,4/>", "0"}), //Usage index 5
        };
    }
}
