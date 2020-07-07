namespace ExtiliaEngine
{
    public class DynamicValueFactory : Factory
    {
        public DynamicValueFactory(string fieldPath, object baseValue, string modifier)
            : base(fieldPath, baseValue, modifier)
        {
        }

        public new object GetValue(Effect effect)
        {
            BaseValue = base.GetValue(effect);
            return BaseValue;
        }

        public object GetValue()
        {
            return BaseValue;
        }
    }
}