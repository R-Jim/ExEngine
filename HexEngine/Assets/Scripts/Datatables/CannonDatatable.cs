public class CannonDatatable : Datatable
{
    public CannonDatatable() : base(GetProperties(), GetEffectActions(), new int[] { 0 }, 0)
    {

    }

    private static DataSet[] GetProperties()
    {
        return new DataSet[] {
            //Init cannon, number of ammo, travel distant of projectile
            new DataSet("model,storage", new string[]{"5", "100", "<in,0/>", "1" }), //Usage index 0
            new DataSet("model,storage", new string[]{"10", "10", "<init,0.CommonPropertySet.~Coordinate/>", "1" }), //Usage index 1
            //Move with collision for projectile
            new DataSet("effect,request", new string[]{ "<action,1/>", "<action,1/>", "1", "2"}),
            new DataSet("effect,move", new string[]{ "<action,1/>", "<action,1/>", "<action,0/>", "0"}),
            new DataSet("effect,chain", new string[]{ "<action,1/>", "<prop,2/>", "<prop,3/>", "1"}),
            new DataSet("effect,collision", new string[]{ "<action,1/>", "<action,1.CommonPropertySet.Coordinate/>", "3"}),
            new DataSet("effect,chain", new string[]{ "<action,1/>", "<prop,4/>", "<prop,5/>", "1"}), //Usage index 6
            //Loop index 6
            new DataSet("effect,chain", new string[]{ "<action,1/>", "<prop,6/>", "1"}), //Usage index 7
            //Firing(Spawn) projectile, and trigger index 7
            new DataSet("effect,request", new string[]{ "<init,0/>", "<init,0/>", "1", "1"}),
            new DataSet("effect,spawn", new string[]{ "<init,0/>", "<action,1/>",  "0"}),
            new DataSet("effect,chain", new string[]{ "<init,0/>", "<prop,8/>", "<prop,9/>", "1"}), //Usage index 10
            new DataSet("effect,chain", new string[]{ "<init,0/>", "<prop,10/>", "<prop,7/>", "1"}), //Usage index 11
        };
    }


    private static EffectActionSet[] GetEffectActions()
    {
        return new EffectActionSet[] {
            new EffectActionSet(1,new int[]{ 1 }, 11),
        };
    }
}
