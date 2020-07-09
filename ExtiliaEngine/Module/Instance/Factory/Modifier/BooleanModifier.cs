namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class BooleanModifier : Modifier
    {
        public BooleanModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            bool baseBool = (bool)baseValue;
            if (inputValue is bool)
            {
                bool inputBool = (bool)inputValue;
                switch (Operator)
                {
                    case "==":
                        return baseBool == inputBool;
                    case "!=":
                        return baseBool != inputBool;
                    default:
                        return baseBool;
                }
            }
            return baseBool;
        }
    }
}
