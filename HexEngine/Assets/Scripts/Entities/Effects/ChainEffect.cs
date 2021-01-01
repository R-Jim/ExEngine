using System.Collections.Generic;
using UnityEngine;

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
        if (HeadEffect.Status == EffectStatus.Pending)
        {
            HeadEffect.Activate(target);
        }
        Status = EffectStatus.Activated;
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        pendingEffectQueue.Enqueue(HeadEffect);
        if (HeadEffect.Status == ChainIfHeadStatus)
        {
            Debug.Log("Chain, " + HeadEffect.GetType() + "/" + TailEffect.GetType());
            pendingEffectQueue.Enqueue(TailEffect);
        }
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        return new ChainEffect(Source, HeadEffect.Clone(), TailEffect.Clone(), ChainIfHeadStatus);
    }
}