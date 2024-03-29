﻿public class CannonDatatable : ModelDatatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions())
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet(ModelPreset.Preset.Storage, new string[]{"10", "100", "100", "<in,0/>", "10", "weapon", "0", "0", "0", null, "1" }), 
            //Move cannon
            new DataSet(EffectPreset.Preset.Modifier, new string[]{ "2", "<action,0/>", "1"  }),
            new DataSet(TriggerPreset.Preset.Target, new string[]{ "<action,0/>", "<action,0/>", "<prop,1/>", "0"}), //Usage index 2
            //
            new DataSet(DatatablePreset.Preset.Bullet, new string[]{ "<prop,11/>" }),
            new DataSet(DatatablePreset.Preset.FiringBullet, new string[]{ "<action,0/>",  "<prop,3/>", "<prop,7/>"}), //Firing normal bullet

            new DataSet(DatatablePreset.Preset.HighImpactBullet, new string[]{ "<prop,11/>" }),
            new DataSet(DatatablePreset.Preset.FiringBullet, new string[]{ "<action,0/>",  "<prop,5/>", "<prop,7/>"}), //Firing high impact bullet

            new DataSet(PropertyPreset.Preset.Vector, new string[]{ "0" }),

            //Spawn dummy
            new DataSet(PropertyPreset.Preset.Coordinate, new string[]{ "<action,0.CommonPropertySet.~Coordinate/>",  "<prop,7/>", "4" }),

            new DataSet(TriggerPreset.Preset.Spawn, new string[]{ "<action,0/>", "<prop,10/>",  "1"}),
            new DataSet(DatatablePreset.Preset.Dummy, new string[]{ "<prop,8/>"}),

            new DataSet(PropertyPreset.Preset.Coordinate, new string[]{ "<action,0.CommonPropertySet.~Coordinate/>",  "<prop,7/>", "1" }),
        };
    }


    private static ActionSet[] GetEffectActions()
    {
        return new ActionSet[] {
            new ActionSet(1, 4),
            new ActionSet(3, 6),
            new ActionSet(2, 2),
            new ActionSet(4, 9),
        };
    }
}
