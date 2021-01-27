public class CannonDatatable : Datatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions(), new int[] { 0 }, 0)
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet("model,storage", new string[]{"5", "100", "100", "<in,0/>", "weapon", "0", "0", "0", "1" }), //Usage index 0
            new DataSet("model,model", new string[]{"10", "10", "<init,0.CommonPropertySet.~Coordinate/>","", "5", "0", "0", "2" }), //Usage index 1
            //Spawn projectile
            new DataSet("trigger,request", new string[]{ "<init,0/>", "1", "1"}),
            new DataSet("trigger,spawn", new string[]{ "<init,0/>", "<action,1/>",  "0"}),
            new DataSet("trigger,chain", new string[]{ "<init,0/>", "<prop,2/>", "<prop,3/>", "0"}), //Usage index 4
            
           // new DataSet("effect,move", new string[]{ null, "<action,0/>"}), //Usage index 12

           //new DataSet("trigger,target", new string[]{ "<init,0/>", "<init,0/>", "<prop,14/>", "0"}),

           //new DataSet("effect,move", new string[]{ null, "<action,0/>"}), //Usage index 14
        };
    }


    private static EffectActionSet[] GetEffectActions()
    {
        return new EffectActionSet[] {
            new EffectActionSet(1,new int[]{ 1 }, 4),
            //new EffectActionSet(2,new int[]{ }, 13),
        };
    }
}
