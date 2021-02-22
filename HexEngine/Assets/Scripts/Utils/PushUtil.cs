using UnityEngine;

class PushUtil
{
    public static float Push(Model sourceModel, CoordinateModifier coordinateModifier, float bonusImpactValue)
    {
        Coordinate EffectedCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();

        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        EffectedCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));

        Model model = ModelContainer.GetModel(EffectedCoordinate);
        if (model == null)
        {
            return CommonPropertySetUtil.GetFullWeight(sourceModel);
        }

        float pushImpactValue = ImpactDamageUtil.GetImpactValue(sourceModel, vectorValue) + bonusImpactValue;
        return PushEffectedModel(pushImpactValue, model, coordinateModifier);
    }

    private static float PushEffectedModel(float pushImpactValue, Model effectedModel, CoordinateModifier coordinateModifier)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;

        float effectedImpactValue = ImpactDamageUtil.GetImpactValue(effectedModel, vectorValue) + CommonPropertySetUtil.GetFullWeight(effectedModel);
        float remainImpactValue = pushImpactValue - effectedImpactValue;
        if (remainImpactValue >= 0)
        {
            remainImpactValue = pushImpactValue - coordinateModifier.Modify(effectedModel, effectedImpactValue);
        }
        Debug.Log("pushValue:" + pushImpactValue + "," + remainImpactValue);
        return remainImpactValue;
    }
}
