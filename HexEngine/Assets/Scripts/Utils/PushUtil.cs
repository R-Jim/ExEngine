using UnityEngine;

class PushUtil
{
    public static float Push(Model sourceModel, CoordinateModifier coordinateModifier, float bonusImpactValue)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        Model model = GetModel(sourceModel, vectorValue);
        float pushImpactValue = ImpactUtil.GetImpactValue(sourceModel, vectorValue) + bonusImpactValue;
        if (model == null)
        {
            return pushImpactValue;
        }

        float remainImpactValue = PushEffectedModel(pushImpactValue, model, coordinateModifier, out float totalImpactValue);
        DamageEffectedModel(sourceModel, model, totalImpactValue);
        return remainImpactValue;
    }

    private static Model GetModel(Model sourceModel, Coordinate.Vector vectorValue)
    {
        Coordinate EffectedCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();
        EffectedCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));
        return ModelContainer.GetModel(EffectedCoordinate);
    }

    private static float PushEffectedModel(float pushImpactValue, Model effectedModel, CoordinateModifier coordinateModifier, out float totalImpactValue)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;

        float effectedImpactValue = ImpactUtil.GetImpactValue(effectedModel, vectorValue);
        float remainImpactValue = pushImpactValue - effectedImpactValue;
        if (remainImpactValue >= 0)
        {
            remainImpactValue = coordinateModifier.Modify(effectedModel, remainImpactValue);
        }
        totalImpactValue = pushImpactValue + effectedImpactValue - remainImpactValue;
        return remainImpactValue;
    }

    private static void DamageEffectedModel(Model sourceModel, Model effectedModel, float impactValue)
    {
        DamageUtil.DamageModel(effectedModel, sourceModel, impactValue);
        DamageUtil.DamageModel(sourceModel, effectedModel, impactValue);
    }
}
