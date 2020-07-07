using System;
namespace ExtiliaEngine
{
    public class Util
    {
        public static object GetFieldValue(string fieldPath, object inputObject)
        {
            try
            {
                string[] paths = fieldPath.Split(".");
                object transferObject = inputObject;
                foreach (string path in paths)
                {
                    transferObject = transferObject.GetType().GetProperty(path).GetValue(transferObject, null);
                }
                return transferObject;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}