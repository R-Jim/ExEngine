public class ChainEffect : Effect
{
    public const string TYPE = "chain";
    public Effect HeadEffect { get; }
    public Effect TailEffect { get; }
    public EffectStatus ChainIfHeadStatus { get; }

    public ChainEffect(Model source, Effect head, EffectStatus chainIfHeadStatus) : base(source, null, TYPE, null, head.OffSet)
    {
        HeadEffect = head;
        TailEffect = this;
        ChainIfHeadStatus = chainIfHeadStatus;
    }

    public ChainEffect(Model source, Effect head, Effect tail, EffectStatus chainIfHeadStatus) : base(source, null, TYPE, null, head.OffSet)
    {
        HeadEffect = head;
        TailEffect = tail;
        ChainIfHeadStatus = chainIfHeadStatus;
    }


    public override void Activate(Model target)
    {
        if (HeadEffect.Status == EffectStatus.Pending)
        {
            HeadEffect.Activate(target);
        }
        if (HeadEffect.Status == ChainIfHeadStatus)
        {
            Status = EffectStatus.Activated;
        }
    }

    public override void Execute()
    {
        HeadEffect.Execute();
        PendingEffectObserver.QueueEffect(TailEffect == this ? Clone() : TailEffect);
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        if (TailEffect == this)
        {
            return new ChainEffect(Source, HeadEffect.Clone(), ChainIfHeadStatus);
        }
        return new ChainEffect(Source, HeadEffect.Clone(), TailEffect.Clone(), ChainIfHeadStatus);
    }
}