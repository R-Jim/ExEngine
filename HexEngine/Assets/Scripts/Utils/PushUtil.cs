class PushUtil
{
    public static float Push(Model sourceModel, CoordinateModifier coordinateModifier, float impactValue, BattleHandler battleHandler)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        Coordinate destinationCoordinate = GetDestinationCoordinate(sourceModel, vectorValue);

        Model occupiedModel = battleHandler.GetModel(destinationCoordinate);
        if (occupiedModel != null)
        {
            return impactValue;
        }
        // Push occupied model
        float remainImpactValue = coordinateModifier.Modify(battleHandler, occupiedModel, impactValue);

        DamageEffectedModel(sourceModel, occupiedModel, vectorValue, impactValue);
        return remainImpactValue;
    }

    private static Coordinate GetDestinationCoordinate(Model sourceModel, Coordinate.Vector vectorValue)
    {
        Coordinate destinationCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();
        destinationCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));
        return destinationCoordinate;
    }

    private static void DamageEffectedModel(Model sourceModel, Model effectedModel, Coordinate.Vector vector, float impactValue)
    {
        DamageUtil.DamageModel(sourceModel, effectedModel, vector, impactValue);
        DamageUtil.DamageModel(effectedModel, sourceModel, CoordinateUtil.RevertVector(vector), impactValue);
    }
}
