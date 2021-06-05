using System;

public class GetPropertyUtil
{
    public static int GetFullProperty(Model model, string type)
    {
        return (int)Math.Ceiling(ModelUtil.GetModelFullPropertyByFunctionWithInputObjects(model, GetProperty, new object[] { type }));
    }

    public static float GetProperty(Model model, object[] inputObjects)
    {
        string propertyType = (string)inputObjects[0];
        return ((StorageModel)model).StoragePropertySet.Current;
    }
}
