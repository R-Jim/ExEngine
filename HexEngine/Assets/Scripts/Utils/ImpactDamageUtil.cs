using System;

class ImpactDamageUtil
{
    public static void Damage(Model sourceModel, Model effectedModel)
    {
        Coordinate.Vector vectorDirection = sourceModel.CommonPropertySet.Coordinate.Pivot;


        //DamageUtil.DamageModel(effectedModel, sourceModel, GetImpactValue(sourceModel, vectorDirection));
        //DamageUtil.DamageModel(sourceModel, effectedModel, GetImpactValue(effectedModel, vectorDirection));
    }

    public static float GetImpactValue(Model model, Coordinate.Vector vectorDirection)
    {
        float totalMomentum = Math.Abs(model.CommonPropertySet.MomentumPropertySet.GetTotalMomentumByDirection(vectorDirection));
        int modelWeight = CommonPropertySetUtil.GetFullWeight(model);
        return modelWeight * totalMomentum;
    }
}
