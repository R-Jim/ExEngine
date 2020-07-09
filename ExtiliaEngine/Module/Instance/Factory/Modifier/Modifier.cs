namespace ExtiliaEngine.Module.Instance.Factory.Modifier
{
    public class Modifier
    {
        public string Operator { get; }
        public Modifier(string operatorString)
        {
            Operator = operatorString;
        }

        public virtual object GetModifiedValue(object baseValue, object inputValue)
        {
            return baseValue;
        }
    }
}
