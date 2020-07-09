using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class ListModifier : Modifier
    {
        public ListModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            List<object> baseList = (List<object>) baseValue;
            double inputDouble = (double)inputValue;
            switch (Operator)
            {
                case "Add":
                    baseList.Add(inputValue);
                    break;
                case "Remove":
                    baseList.Remove(inputDouble);
                    break;
                default:
                    List<object> modifiedList = new List<object>();
                    foreach(object item in baseList)
                    {
                        Modifier modifier = ModifierController.GetModifier(Operator, baseValue);
                        modifiedList.Add(modifier.GetModifiedValue(item, inputValue));
                    }
                    return modifiedList;
            }
            return baseList;
        }
    }
}
