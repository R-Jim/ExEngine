using System.Collections.Generic;

public class RequestEffect : Effect
{
    public const string TYPE = "request";

    public int RequireValue;
    public RequestEffect(Model source, Storage storage, int requireValue, Effect requestedEffect) : base(source, null, TYPE, requestedEffect)
    {
        TargetList.Add(storage);
        RequireValue = requireValue;
    }

    public override void Activate(Model unusedModel)
    {
        Storage storage = (Storage)TargetList[0];
        if (RequestTrigger.IsTriggered(storage, RequireValue))
        {
            Status = EffectStatus.Activated;
        }
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        pendingEffectQueue.Enqueue((Effect)Value);
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        return new RequestEffect(Source, (Storage)TargetList[0], RequireValue, (Effect)Value);
    }
}
