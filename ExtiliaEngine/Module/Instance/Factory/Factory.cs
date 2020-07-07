using System.Collections.Generic;
namespace ExtiliaEngine
{
    public class Factory
    {
        protected string FieldPath { get; }
        protected object BaseValue;
        protected string Modifier { get; }

        public Factory(object baseValue)
            : this(null, baseValue, null)
        {

        }

        public Factory(string fieldPath)
            : this(fieldPath, null, null)
        {

        }

        public Factory(string fieldPath, object baseValue, string modifier)
        {
            FieldPath = fieldPath;
            BaseValue = baseValue;
            Modifier = modifier;
        }

        public object GetValue(Effect effect)
        {
            object fieldValue = Util.GetFieldValue(FieldPath, effect);

            //double
            if (fieldValue is List<double>)
            {
                return ((List<double>)fieldValue).ConvertAll(value =>
                {
                    return ModifyValue(value);
                });
            }
            else if (fieldValue is double)
            {
                return ModifyValue((double)fieldValue);
            }

            //Coordinate
            else if (fieldValue is List<Coordinate>)
            {
                return ((List<Coordinate>)fieldValue).ConvertAll(value =>
                {
                    return ModifyValue(value);
                });
            }
            else if (fieldValue is Coordinate)
            {
                return ModifyValue((Coordinate)fieldValue);
            }

            //Instance
            else if (fieldValue is Instance)
            {
                return ((List<Instance>)fieldValue).ConvertAll(value =>
                {
                    return ModifyValue(value);
                });
            }
            else if (fieldValue is Instance)
            {
                return ModifyValue((Instance)fieldValue);
            }

            else
            {
                return BaseValue;
            }
        }

        private object ModifyValue(double inputValue)
        {
            if (!(BaseValue is double))
            {
                return inputValue;
            }
            double baseDouble = (double)BaseValue;
            switch (Modifier)
            {
                case "+":
                    return baseDouble + inputValue;
                case "*":
                    return baseDouble * inputValue;
                default:
                    return baseDouble;
            }
        }

        private object ModifyValue(Coordinate inputValue)
        {
            if (!(BaseValue is Coordinate))
            {
                return inputValue;
            }

            Coordinate baseCoordinate = (Coordinate)BaseValue;
            switch (Modifier)
            {
                case "+":
                    return new Coordinate(baseCoordinate.X + inputValue.X, baseCoordinate.Y + inputValue.Y);
                case "*":
                    return new Coordinate(baseCoordinate.X * inputValue.X, baseCoordinate.Y * inputValue.Y);
                default:
                    return baseCoordinate;
            }
        }

        private object ModifyValue(Instance inputValue)
        {
            if (!(BaseValue is List<Instance>))
            {
                return inputValue;
            }

            List<Instance> baseInstanceList = (List<Instance>)BaseValue;
            switch (Modifier)
            {
                case "+":
                    baseInstanceList.Add(inputValue);
                    break;
                case "-":
                    baseInstanceList.Remove(inputValue);
                    break;
            }
            return baseInstanceList;
        }
    }
}