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
}
