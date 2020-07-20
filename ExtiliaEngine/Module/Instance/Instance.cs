namespace ExtiliaEngine
{
    public class Instance
    {
        public string Id { get; }
        public string[] Tags { get; }
        private DynamicValueFactory ValueFactory;
        public object Value { get { return ValueFactory.GetValue(); } }

        private Trigger Trigger { get; }

        public Instance(string id, string[] tags,
            DynamicValueFactory valueFactory, Trigger trigger
            )
        {
            Id = id;
            Tags = tags;
            ValueFactory = valueFactory;
            Trigger = trigger;
        }

        public Effect OnEffect(Effect effect)
        {
            if (Trigger.IsTriggered(effect))
            {
                Effect targetedEffect = effect.NewEffectWithTarget(this);
                if (ValueFactory != null)
                {
                    ValueFactory.GetValue(targetedEffect);
                }
                return Trigger.GetEffect(targetedEffect);
            }
            return null;
        }
    }

}
