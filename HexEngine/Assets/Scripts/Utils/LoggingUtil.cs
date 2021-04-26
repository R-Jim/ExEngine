public class LoggingUtil
{
    public static string GetModelLoggingIdentifier(Model model)
    {
        string modelMountType = model?.CommonPropertySet?.MountType;
        return "[" + modelMountType + "]";
    }
}
