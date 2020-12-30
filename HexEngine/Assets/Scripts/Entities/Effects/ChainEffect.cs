using System.Collections.Generic;

public class ChainEffect : Effect
{
    public const string TYPE = "chain";
    public Effect HeadEffect { get; }
    public Effect TailEffect { get; }
    public EffectStatus ChainIfHeadStatus { get; }

    public ChainEffect(Model source, Effect head, Effect tail, EffectStatus chainIfHeadStatus) : base(source, null, TYPE, null)
    {
        HeadEffect = head;
        TailEffect = tail;
        ChainIfHeadStatus = chainIfHeadStatus;
    }


    public override void Activate(Model target)
    {
        HeadEffect.Activate(target);
        Status = EffectStatus.Activated;
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        pendingEffectQueue.Enqueue(HeadEffect);
        if(HeadEffect.Status == ChainIfHeadStatus)
        {
            pendingEffectQueue.Enqueue(TailEffect);
        }
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        return new ChainEffect(Source, HeadEffect.Clone(), TailEffect.Clone(), ChainIfHeadStatus);
    }
}