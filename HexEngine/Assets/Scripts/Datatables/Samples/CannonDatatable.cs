public class CannonDatatable : ModelDatatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet(ModelPreset.Preset.Storage, new string[]{"10", "100", "100", "<in,0/>", "10", "weapon", "0", "0", "0", "1" }), 
            //Move cannon
            new DataSet(EffectPreset.Preset.Modifier, new string[]{ "2", "<action,0/>", "1"  }),
            new DataSet(TriggerPreset.Preset.Target, new string[]{ "<action,0/>", "<action,0/>", "<prop,1/>", "0"}), //Usage index 2
            //
            new DataSet(DatatablePreset.Preset.Bullet, new string[]{ "<action,0/>" }),
            new DataSet(DatatablePreset.Preset.FiringBullet, new string[]{ "<action,0/>",  "<prop,3/>", "<prop,5/>"}),
            new DataSet(PropertyPreset.Preset.Vector, new string[]{ "0" })
        };
    }


    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
            new ActionSet(1, 4),
            new ActionSet(2, 2),
        };
    }
}
