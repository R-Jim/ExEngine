using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class BooleanListModifier : Modifier
    {
        public BooleanListModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            List<bool> baseList = (List<bool>)baseValue;
            bool inputInstance = (bool)inputValue;
            switch (Operator)
            {
                case "Add":
                    baseList.Add(inputInstance);
                    break;
                case "Remove":
                    baseList.Remove(inputInstance);
                    break;
                default:
                    List<bool> modifiedList = new List<bool>();
                    foreach (bool item in baseList)
                    {
                        Modifier modifier = ModifierController.GetModifier(Operator, baseValue);
                        modifiedList.Add((bool)modifier.GetModifiedValue(item, inputInstance));
                    }
                    return modifiedList;
            }
            return baseList;
        }
    }
}
