using System;

public class CombatPropertySetUtil
{
    public static int GetFullDamage(Model model, Coordinate.Vector vector)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetFullPropertyByFunction(upMostModel, GetDamage, new object[] { vector }));
    }

    public static float GetDamage(Model model, object[] inputObjects)
    {
        Coordinate.Vector vector = (Coordinate.Vector)inputObjects[0];
        if (model == null)
        {
            return 0;
        }
        VectorBasedIntPropertySet damagePropertySet = model.CommonPropertySet.DamageValuePropertySet;

        return damagePropertySet.GetValue(CoordinateUtil.AdjustVector(model.CommonPropertySet.FacingDirection, vector));
    }
}
