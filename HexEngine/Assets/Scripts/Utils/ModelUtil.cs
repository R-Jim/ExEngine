using System;

public class ModelUtil
{

    public static float GetModelFullPropertyByFunction(Model model, Func<Model, float> getPropertyValueFunction)
    {
        float propertyValue = getPropertyValueFunction(model);
        if (model.MountPoints == null)
        {
            return propertyValue;
        }
        foreach (MountPoint mountPoint in model.MountPoints)
        {
            propertyValue += GetModelFullPropertyByFunction(mountPoint.MountedModel, getPropertyValueFunction);
        }
        return propertyValue;
    }

    public static float GetModelFullPropertyByFunctionWithInputObjects(Model model, Func<Model, object[], float> getPropertyValueFunction, object[] inputObjects)
    {
        float propertyValue = getPropertyValueFunction(model, inputObjects);
        if (model.MountPoints == null)
        {
            return propertyValue;
        }
        foreach (MountPoint mountPoint in model.MountPoints)
        {
            propertyValue += GetModelFullPropertyByFunctionWithInputObjects(mountPoint.MountedModel, getPropertyValueFunction, inputObjects);
        }
        return propertyValue;
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
}
