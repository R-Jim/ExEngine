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

        float remainImpactValue = PushEffectedModel(pushImpactValue, model, coordinateModifier, out float totalImpactValue);
        return remainImpactValue;
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
        Debug.Log("pushValue:" + pushImpactValue + "," + remainImpactValue);
        totalImpactValue = pushImpactValue + effectedImpactValue - remainImpactValue;
        return remainImpactValue;
    }
}
