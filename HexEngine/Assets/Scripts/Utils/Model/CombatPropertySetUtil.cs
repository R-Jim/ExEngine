using System;

public class CombatPropertySetUtil
{
    public static DamagePropertySet GetDamage(Model model, Coordinate.Vector vector)
    {
        if (model == null)
        {
            return new DamagePropertySet(0, 0);
        }

        Coordinate.Vector trueVector = CoordinateUtil.AdjustVector(model.CommonPropertySet.FacingDirection, vector);
        return (DamagePropertySet)model.ModelDatatable.GetDamageVectorPropertySet().GetValue(trueVector);
    }
}
