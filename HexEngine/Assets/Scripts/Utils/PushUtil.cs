using UnityEngine;

class PushUtil
{
    public static float Push(Model sourceModel, CoordinateModifier coordinateModifier, float bonusImpactValue)
    {
        Coordinate EffectedCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();

        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        EffectedCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));

        Model model = ModelContainer.GetModel(EffectedCoordinate);
        float pushImpactValue = ImpactUtil.GetImpactValue(sourceModel, vectorValue) + bonusImpactValue;
        if (model == null)
        {
            return pushImpactValue;
        }

        return PushEffectedModel(pushImpactValue, model, coordinateModifier);
    }

    private static float PushEffectedModel(float pushImpactValue, Model effectedModel, CoordinateModifier coordinateModifier)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;

        float effectedImpactValue = ImpactUtil.GetImpactValue(effectedModel, vectorValue);
        float remainImpactValue = pushImpactValue - effectedImpactValue;
        if (remainImpactValue >= 0)
        {
            remainImpactValue = coordinateModifier.Modify(effectedModel, remainImpactValue);
        }
        Debug.Log("pushValue:" + pushImpactValue + "," + remainImpactValue);
        return remainImpactValue;
    }
}
