using System.Collections.Generic;

class PushUtil
{
    public static bool Push(Model sourceModel, CoordinateModifier coordinateModifier)
    {
        Coordinate EffectedCoordinate = sourceModel.CommonPropertySet.Coordinate.Clone();
        Coordinate.Vector vectorValue = (Coordinate.Vector)coordinateModifier.Value;
        EffectedCoordinate.Add(CoordinateUtil.GetCoordinate(vectorValue));

        List<Model> effectedModelList = ModelContainer.GetModelList(EffectedCoordinate);
        HashSet<Model> effectedModelSet = GetUpMostModelSet(effectedModelList);

        if (effectedModelSet.Count == 0)
        {
            return true;
        }
        return PushEffectedModelSet(sourceModel, effectedModelSet, vectorValue);
    }

    private static bool PushEffectedModelSet(Model sourceModel, HashSet<Model> effectedModelSet, Coordinate.Vector vectorValue)
    {
        bool pushedAModel = false;

        foreach (Model effectedModel in effectedModelSet)
        {
            ImpactDamageUtil.Damage(sourceModel, effectedModel);
            if (PushEffectedModel(sourceModel, effectedModel, vectorValue))
            {
                pushedAModel = true;
            };
        }
        return pushedAModel;
    }

    private static bool PushEffectedModel(Model sourceModel, Model effectedModel, Coordinate.Vector vectorValue)
    {
        if (GetImpactValue(sourceModel) > GetImpactValue(effectedModel))
        {
            effectedModel.CommonPropertySet.MomentumPropertySet.Add(new VectorPropertySet(vectorValue));
            return true;
        }
        return false;
    }

    private static HashSet<Model> GetUpMostModelSet(List<Model> modelList)
    {
        HashSet<Model> upMostModelSet = new HashSet<Model>();
        foreach (Model model in modelList)
        {
            upMostModelSet.Add(CommonPropertySetUtil.GetUpMostModel(model));
        }
        return upMostModelSet;
    }

    private static float GetImpactValue(Model model)
    {
        int weight = CommonPropertySetUtil.GetFullWeight(model);
        return weight * model.CommonPropertySet.MomentumPropertySet.GetTotalMomentum();
    }
}
