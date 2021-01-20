public class ChainEffect : Effect
{
    public ChainEffect(Trigger trigger, ChainTrigger.ChainSet chainSet) : base(trigger, chainSet)
    {

    }

    public override void Execute()
    {
        ChainTrigger.ChainSet chainSet = (ChainTrigger.ChainSet)Value;
        Effect headEffect = chainSet.HeadTrigger.BaseEffect.Bind(TargetModel);
        headEffect.Execute();

        TriggerObserver.QueueTrigger(chainSet.TailTrigger);
        Status = EffectStatus.Executed;
        AssignEffectAfterExecuted();
    }

    public override Effect Bind(Model model)
    {
        ChainTrigger.ChainSet chainSet = (ChainTrigger.ChainSet)Value;
        Effect effect = new ChainEffect(Trigger, new ChainTrigger.ChainSet(chainSet.HeadTrigger, chainSet.TailTrigger, chainSet.Type))
        {
            TargetModel = model
        };
        return effect;
    }
}