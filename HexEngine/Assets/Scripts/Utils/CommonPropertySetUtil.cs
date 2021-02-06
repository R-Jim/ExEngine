public class CommonPropertySetUtil
{
    public static Model GetUpMostModel(Model model)
    {
        MountPoint mountPoint = model.CommonPropertySet.MountedTo;
        if (mountPoint != null)
        {
            return GetUpMostModel(mountPoint.SourceModel);
        }
        return model;
    }

    public static bool IsModelMountedTo(Model sourceModel, Model mountedModel)
    {
        MountPoint mountPoint = sourceModel.CommonPropertySet.MountedTo;
        if (mountPoint == null)
        {
            return false;
        }
        while (mountPoint != null)
        {
            if (mountPoint.SourceModel.GetHashCode() == mountedModel.GetHashCode())
            {
                return true;
            }
            mountPoint = mountPoint.SourceModel.CommonPropertySet.MountedTo;
        }
        return false;
    }

    public static int GetFullWeight(Model model)
    {
        Model upMostModel = GetUpMostModel(model);
        return GetModelFullWeight(upMostModel);
    }

    private static int GetModelFullWeight(Model model)
    {
        if (model == null)
        {
            return 0;
        }
        int weight = model.CommonPropertySet.Weight;
        if (model.MountPoints == null)
        {
            return weight;
        }
        foreach (MountPoint mountPoint in model.MountPoints)
        {
            weight += GetModelFullWeight(mountPoint.MountedModel);
        }
        return weight;
    }

    public static int GetFullMountedModelCount(Model model)
    {
        Model upMostModel = GetUpMostModel(model);
        return GetModelFullMountedModelCount(upMostModel);
    }

    private static int GetModelFullMountedModelCount(Model model)
    {
        if (model == null)
        {
            return 0;
        }
        int numberOfMountedModel = 1;
        if (model.MountPoints == null)
        {
            return numberOfMountedModel;
        }
        foreach (MountPoint mountPoint in model.MountPoints)
        {
            numberOfMountedModel += GetModelFullMountedModelCount(mountPoint.MountedModel);
        }
        return numberOfMountedModel;
    }
}
