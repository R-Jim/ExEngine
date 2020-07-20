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

        public bool IsMatchCondition(Effect effect)
        {
            object effectValue = Util.GetFieldValue(FieldPath, effect);
            switch (Operator)
            {
                case "has":
                    if (!(BaseValue is Array))
                    {
                        return false;
                    }
                    return IsObjectInArray(effectValue, (Array)BaseValue);
                case "in":
                    if (!(effectValue is Array))
                    {
                        return false;
                    }
                    return IsObjectInArray(BaseValue, (Array)effectValue);
                case "=":
                    return BaseValue.Equals(effectValue);
                case "!=":
                    return !BaseValue.Equals(effectValue);
                default:
                    if (effectValue is double)
                    {
                        return CompareDouble((double)effectValue);
                    }
                    else if (effectValue is Coordinate)
                    {
                        return CompareCoordinate((Coordinate)effectValue);
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