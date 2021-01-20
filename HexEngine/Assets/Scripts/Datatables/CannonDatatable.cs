public class CannonDatatable : Datatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions(), new int[] { 0 }, 0)
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet("model,storage", new string[]{"5", "100", "<in,0/>", "weapon", "1" }), //Usage index 0
            new DataSet("model,storage", new string[]{"4", "4", "<init,0.CommonPropertySet.~Coordinate/>","", "2" }), //Usage index 1
            //Move with collision for projectile
            new DataSet("trigger,request", new string[]{ "<action,1/>", "1", "2"}),
            new DataSet("trigger,target", new string[]{ "<action,1/>", "<action,1/>", "<prop,12/>", "0"}),
            new DataSet("trigger,chain", new string[]{ "<action,1/>", "<prop,2/>", "<prop,3/>", "0"}),
            new DataSet("trigger,collision", new string[]{ "<action,1/>", "<action,1.CommonPropertySet.Coordinate/>", "10", "3"}),
            new DataSet("trigger,chain", new string[]{ "<action,1/>", "<prop,4/>", "<prop,5/>", "0"}), //Usage index 6
            //Loop index 6
            new DataSet("trigger,chain", new string[]{ "<action,1/>", "<prop,6/>", null, "0", "true"}), //Usage index 7
            //Firing(Spawn) projectile, and trigger index 7
            new DataSet("trigger,request", new string[]{ "<init,0/>", "1", "1"}),
            new DataSet("trigger,spawn", new string[]{ "<init,0/>", "<action,1/>",  "0"}),
            new DataSet("trigger,chain", new string[]{ "<init,0/>", "<prop,9/>", "<prop,7/>", "0"}), //Usage index 10
            new DataSet("trigger,chain", new string[]{ "<init,0/>", "<prop,8/>", "<prop,10/>", "0"}), //Usage index 11
            
            new DataSet("effect,move", new string[]{ null, "<action,0/>"}), //Usage index 12
        };
    }


    private static EffectActionSet[] GetEffectActions()
    {
        return new EffectActionSet[] {
            new EffectActionSet(1,new int[]{ 1 }, 11),
        };
    }
}
