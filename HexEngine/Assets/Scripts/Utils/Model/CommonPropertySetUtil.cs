using System;

public class CommonPropertySetUtil
{
    public static Model GetUpMostModel(Model model)
    {
        if (model == null)
        {
            return null;
        }
        MountPoint mountPoint = model.CommonPropertySet.MountedTo;
        if (mountPoint != null)
        {
            return GetUpMostModel(mountPoint.SourceModel);
        }
        return model;
    }

    public static int GetFullWeight(Model model)
    {
        Model upMostModel = GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunction(upMostModel, GetModelWeight));
    }

    private static float GetModelWeight(Model model)
    {
        if (model == null)
        {
            return 0;
        }
        return model.CommonPropertySet.Weight;
    }

    public static int GetFullMountedModelCount(Model model)
    {
        Model upMostModel = GetUpMostModel(model);
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunction(upMostModel, GetModelCount));
    }

    private static float GetModelCount(Model model)
    {
        if (model == null)
        {
            return 0;
        }
        return 1;
    }
}
