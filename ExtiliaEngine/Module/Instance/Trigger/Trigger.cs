using System.Collections.Generic;
namespace ExtiliaEngine
{
    public class Trigger
    {
        private List<Condition> Conditions;
        public EffectFactory EffectFactory { get; }

        public Trigger(List<Condition> conditions, EffectFactory effectFactory)
        {
            Conditions = conditions;
            EffectFactory = effectFactory;
        }

        public bool IsTriggered(Effect effect)
        {
            return !Conditions.Exists(condition => !condition.IsMatchCondition(effect));
        }

        public Effect GetEffect(Effect effect)
        {
            return EffectFactory.GetEffect(effect);
        }
    }
}