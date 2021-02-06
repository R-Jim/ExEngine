public class CannonDatatable : Datatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions(), new int[] { 0 }, 0)
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet("model,storage", new string[]{"5", "100", "100", "<in,0/>", "10", "weapon", "0", "0", "0", "1" }), //Usage index 0
            new DataSet("model,model", new string[]{"2", "2", "<action,0/>", "1", "", "0", "0", "0", "2" }), //Usage index 1
            //Spawn projectile
            new DataSet("trigger,request", new string[]{ "<init,0/>", "1", "1"}),
            new DataSet("trigger,spawn", new string[]{ "<init,0/>", "<action,2/>",  "0"}),
            new DataSet("trigger,chain", new string[]{ "<init,0/>", "<prop,2/>", "<prop,3/>", "0"}), //Usage index 4
            new DataSet("effect,modifier", new string[]{ "2", "<action,1/>", "5" }),
            new DataSet("trigger,target", new string[]{ "<action,2/>", "<action,2/>", "<prop,5/>", "0"}), //Usage index 6
            new DataSet("trigger,chain", new string[]{ "<init,0/>", "<prop,4/>", "<prop,6/>", "0"}), //Usage index 7
            //Move cannon
            new DataSet("effect,modifier", new string[]{ "2", "<action,0/>", "1"  }),
            new DataSet("trigger,target", new string[]{ "<init,0/>", "<init,0/>", "<prop,8/>", "0"}), //Usage index 9
        };
    }


    private static EffectActionSet[] GetEffectActions()
    {
        return new EffectActionSet[] {
            new EffectActionSet(1, new int[]{ 1 }, 7),
            new EffectActionSet(2, new int[]{ }, 9),
        };
    }
}
