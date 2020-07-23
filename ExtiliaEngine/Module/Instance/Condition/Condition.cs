using System;
using System.Data;
namespace ExtiliaEngine
{
    public class Condition
    {
        public string FieldPath { get; }
        public string Operator { get; }
        protected object BaseValue;

        public Condition(string fieldPath, string conditionOperator, object baseValue)
        {
            FieldPath = fieldPath;
            Operator = conditionOperator;
            BaseValue = baseValue;
        }

        public bool IsMatchCondition(object inputObject)
        {
            object inputValue = Util.GetFieldValue(FieldPath, inputObject);
            switch (Operator)
            {
                case "has":
                    if (!(BaseValue is Array))
                    {
                        return false;
                    }
                    return IsObjectInArray(inputValue, (Array)BaseValue);
                case "in":
                    if (!(inputValue is Array))
                    {
                        return false;
                    }
                    return IsObjectInArray(BaseValue, (Array)inputValue);
                case "=":
                    return BaseValue.Equals(inputValue);
                case "!=":
                    return !BaseValue.Equals(inputValue);
                default:
                    if (inputValue is double)
                    {
                        return CompareDouble((double)inputValue);
                    }
                    else if (inputValue is Coordinate)
                    {
                        return CompareCoordinate((Coordinate)inputValue);
                    }
                    return false;
            }
        }

        private bool IsObjectInArray(object objectItem, Array array)
        {
            foreach (object item in array)
            {
                if (item.Equals(objectItem))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CompareDouble(double value)
        {
            if (!(BaseValue is double))
            {
                return false;
            }
            double baseDouble = (double)BaseValue;
            return Convert.ToBoolean(new DataTable().Compute(baseDouble + Operator + value, "false"));
        }

        private bool CompareCoordinate(Coordinate coordinate)
        {
            // Operator should be "X,="
            string[] OperatorWithField = Operator.Split(',');
            if (OperatorWithField.Length < 2 || !(BaseValue is Coordinate))
            {
                return false;
            }

            double baseValue = (double)Util.GetFieldValue(OperatorWithField[0], (Coordinate)BaseValue);
            double compareValue = (double)Util.GetFieldValue(OperatorWithField[0], coordinate);
            string operation = baseValue + OperatorWithField[1].Replace("!=", "<>") + compareValue;
            return Convert.ToBoolean(new DataTable().Compute(operation, "false"));
        }
    }
}