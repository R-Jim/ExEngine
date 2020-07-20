using System;

namespace ExtiliaEngine
{
    public class Util
    {
        public static object GetFieldValue(string fieldPath, object inputObject)
        {
            try
            {
                string[] paths = fieldPath.Split('.');
                object transferObject = inputObject;
                foreach (string path in paths)
                {
                    if (transferObject is Coordinate)
                    {
                        transferObject = GetValueFromCoordinate(path, (Coordinate)transferObject);
                    }
                    else if (transferObject is Condition)
                    {
                        transferObject = GetValueFromCondition(path, (Condition)transferObject);
                    }
                    else if (transferObject is Trigger)
                    {
                        transferObject = GetValueFromTrigger(path, (Trigger)transferObject);
                    }
                    else if (transferObject is Effect)
                    {
                        transferObject = GetValueFromEffect(path, (Effect)transferObject);
                    }
                    else if (transferObject is Instance)
                    {
                        transferObject = GetValueFromInstance(path, (Instance)transferObject);
                    }
                }
                return transferObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static object GetValueFromInstance(string path, Instance inputObject)
        {
            switch (path)
            {
                case "Id":
                    return inputObject.Id;
                case "Tags":
                    return inputObject.Tags;
                case "Value":
                    return inputObject.Value;
            }
            return null;
        }


        private static object GetValueFromEffect(string path, Effect inputObject)
        {
            switch (path)
            {
                case "Types":
                    return inputObject.Types;
                case "Coordinate":
                    return inputObject.Coordinate;
                case "Value":
                    return inputObject.Value;
                case "Source":
                    return inputObject.Source;
                case "Target":
                    return inputObject.Target;
            }
            return null;
        }

        private static object GetValueFromTrigger(string path, Trigger inputObject)
        {
            switch (path)
            {
                case "EffectFactory":
                    return inputObject.EffectFactory;
            }
            return null;
        }

        private static object GetValueFromCondition(string path, Condition inputObject)
        {
            switch (path)
            {
                case "FieldPath":
                    return inputObject.FieldPath;
                case "Operator":
                    return inputObject.Operator;
            }
            return null;
        }

        private static object GetValueFromCoordinate(string path, Coordinate inputObject)
        {
            switch (path)
            {
                case "X":
                    return inputObject.X;
                case "Y":
                    return inputObject.Y;
            }
            return null;
        }
    }
}