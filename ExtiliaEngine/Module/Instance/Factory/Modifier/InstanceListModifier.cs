using System;
using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class InstanceListModifier : Modifier
    {
        public InstanceListModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            List<ExtiliaEngine.Instance> baseList = (List<ExtiliaEngine.Instance>)baseValue;
            ExtiliaEngine.Instance inputInstance = (ExtiliaEngine.Instance)inputValue;
            switch (Operator)
            {
                case "Add":
                    baseList.Add(inputInstance);
                    break;
                case "Remove":
                    baseList.Remove(inputInstance);
                    break;
                default:
                    List<ExtiliaEngine.Instance> modifiedList = new List<ExtiliaEngine.Instance>();
                    foreach (ExtiliaEngine.Instance item in baseList)
                    {
                        Modifier modifier = ModifierController.GetModifier(Operator, baseValue);
                        modifiedList.Add((ExtiliaEngine.Instance)modifier.GetModifiedValue(item, inputInstance));
                    }
                    return modifiedList;
            }
            return baseList;
        }
    }
}
