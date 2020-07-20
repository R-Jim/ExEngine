using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class DoubleListModifier : Modifier
    {
        public DoubleListModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            List<double> baseList = (List<double>)baseValue;
            double inputInstance = (double)inputValue;
            switch (Operator)
            {
                case "Add":
                    baseList.Add(inputInstance);
                    break;
                case "Remove":
                    baseList.Remove(inputInstance);
                    break;
                default:
                    List<double> modifiedList = new List<double>();
                    foreach (double item in baseList)
                    {
                        Modifier modifier = ModifierController.GetModifier(Operator, baseValue);
                        modifiedList.Add((double)modifier.GetModifiedValue(item, inputInstance));
                    }
                    return modifiedList;
            }
            return baseList;
        }
    }
}
