using System;

class ImpactDamageUtil
{
    public static void Damage(Model sourceModel, Model effectedModel)
    {
        Coordinate.Vector vectorDirection = sourceModel.CommonPropertySet.Coordinate.Pivot;


        DamageUtil.DamageModel(effectedModel, sourceModel, vectorDirection);
        DamageUtil.DamageModel(sourceModel, effectedModel, vectorDirection);
    }

    public static int GetImpactValue(Model model, Coordinate.Vector vectorDirection)
    {

        return (int)Math.Round(
            CommonPropertySetUtil.GetFullWeight(model)
            * (model.CommonPropertySet.MomentumPropertySet.GetTotalMomentumByDirection(vectorDirection) + 1)
            );
    }
}
