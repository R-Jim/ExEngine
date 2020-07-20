using System.Collections.Generic;

namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class CoordinateListModifier : Modifier
    {
        public CoordinateListModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            List<Coordinate> baseList = (List<Coordinate>)baseValue;
            Coordinate inputInstance = (Coordinate)inputValue;
            switch (Operator)
            {
                case "Add":
                    baseList.Add(inputInstance);
                    break;
                case "Remove":
                    baseList.Remove(inputInstance);
                    break;
                default:
                    List<Coordinate> modifiedList = new List<Coordinate>();
                    foreach (Coordinate item in baseList)
                    {
                        Modifier modifier = ModifierController.GetModifier(Operator, baseValue);
                        modifiedList.Add((Coordinate)modifier.GetModifiedValue(item, inputInstance));
                    }
                    return modifiedList;
            }
            return baseList;
        }
    }
}
