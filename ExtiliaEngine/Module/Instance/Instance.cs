namespace ExtiliaEngine
{
    public class Instance
    {
        public string Id { get; }
        public string[] Tags { get; }
        private DynamicValueFactory ValueFactory;
        public object Value { get { return ValueFactory.GetValue(); } }

        private Trigger TriggerEffect;
        public Trigger TriggerRemoval;

        public Instance(string id, string[] tags,
            DynamicValueFactory valueFactory, Trigger trigger
            )
        {
            Id = id;
            Tags = tags;
            ValueFactory = valueFactory;
            TriggerEffect = trigger;
        }

        public Effect OnEffect(Effect effect)
        {
            if (TriggerEffect.IsTriggered(effect))
            {
                Effect targetedEffect = effect.NewEffectWithTarget(this);
                if (ValueFactory != null)
                {
                    ValueFactory.GetValue(targetedEffect);
                }
                return TriggerEffect.GetEffect(targetedEffect);
            }
            return null;
        }
    }

}
