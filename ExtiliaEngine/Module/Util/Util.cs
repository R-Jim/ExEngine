using System;
using System.Reflection;

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
                    Type type = transferObject.GetType();
                    PropertyInfo pI = type.GetProperty(path);
                    transferObject = pI.GetValue(transferObject, null);
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