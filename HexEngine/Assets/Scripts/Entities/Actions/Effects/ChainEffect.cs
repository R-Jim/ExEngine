public class ChainEffect : Effect
{
    public ChainEffect(ChainTrigger.ChainSet chainSet) : base(chainSet)
    {

    }

    protected override void ExecuteProcess()
    {
        ChainTrigger.ChainSet chainSet = (ChainTrigger.ChainSet)Value;
        Effect headEffect = chainSet.HeadTrigger.BaseEffect.Bind(TargetModel);
        headEffect.Execute();

        HandleTailTrigger();
    }

    private void HandleTailTrigger()
    {
        ChainTrigger.ChainSet chainSet = (ChainTrigger.ChainSet)Value;
        Trigger tailTrigger = chainSet.TailTrigger;
        if (tailTrigger is ChainTrigger && ((ChainTrigger)tailTrigger).IsSelfChain)
        {
            tailTrigger.Reset();
        }
        TriggerContainer.QueueTrigger(tailTrigger);
    }

    public override Effect Bind(Model model)
    {
        ChainTrigger.ChainSet chainSet = (ChainTrigger.ChainSet)Value;
        Effect effect = new ChainEffect(new ChainTrigger.ChainSet(chainSet.HeadTrigger, chainSet.TailTrigger, chainSet.Type))
        {
            TargetModel = model
        };
        effect.Trigger = Trigger;
        effect.Trigger.HookedModel.Add(model);
        return effect;
    }
}