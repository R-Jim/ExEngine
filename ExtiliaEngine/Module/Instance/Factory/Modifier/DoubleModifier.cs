namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    class DoubleModifier : Modifier
    {
        public DoubleModifier(string operatorString) : base(operatorString)
        {
        }

        public override object GetModifiedValue(object baseValue, object inputValue)
        {
            double baseDouble = (double)baseValue;
            if (inputValue is double)
            {
                double inputDouble = (double)inputValue;
                switch (Operator)
                {
                    case "+":
                        return baseDouble + inputDouble;
                    case "*":
                        return baseDouble * inputDouble;
                    default:
                        return baseValue;
                }
            }
            return baseValue;
        }
    }
}
