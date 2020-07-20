using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class ModifierController
    {
        public static Modifier GetModifier(string operatorString, object baseValue)
        {
            if (baseValue is double)
            {
                return new DoubleModifier(operatorString);
            }
            else if (baseValue is Coordinate)
            {
                return new CoordinateModifier(operatorString);
            }
            else if (baseValue is bool)
            {
                return new BooleanModifier(operatorString);
            }
            else if (baseValue is List<ExtiliaEngine.Instance>)
            {
                return new InstanceListModifier(operatorString);
            }
            else if (baseValue is List<double>)
            {
                return new DoubleListModifier(operatorString);
            }
            else if (baseValue is List<Coordinate>)
            {
                return new CoordinateListModifier(operatorString);
            }

            else if (baseValue is List<bool>)
            {
                return new BooleanListModifier(operatorString);
            }
            return null;
        }
    }
}
