class PushUtil
{
    public static float Push(Model sourceModel, CoordinateModifier coordinateModifier, float impactValue, BattleHandler battleHandler)
    {
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        Model model = GetModel(sourceModel, vectorValue, battleHandler);
        if (model != null)
        {
            return impactValue;
        }

        float remainImpactValue = coordinateModifier.Modify(battleHandler, model, impactValue);

        DamageEffectedModel(sourceModel, model, vectorValue);
        return remainImpactValue;
    }

    private static Model GetModel(Model sourceModel, Coordinate.Vector vectorValue, BattleHandler battleHandler)
    {
        Coordinate EffectedCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();
        EffectedCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));
        return battleHandler.GetModel(EffectedCoordinate);
    }

    private static void DamageEffectedModel(Model sourceModel, Model effectedModel, Coordinate.Vector vector)
    {
        DamageUtil.DamageModel(sourceModel, effectedModel, vector);
        DamageUtil.DamageModel(effectedModel, sourceModel, CoordinateUtil.RevertVector(vector));
    }
}
