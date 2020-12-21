using System.Collections.Generic;

public class RequestEffect : Effect
{
    public const string TYPE = "request";

    public int RequireValue;
    public RequestEffect(Model source, Storage storage, int requireValue, Coordinate coordinate, Effect requestedEffect) : base(source, coordinate, TYPE, requestedEffect)
    {
        TargetList.Add(storage);
        RequireValue = requireValue;
    }

    public new void Activate(Model unusedModel)
    {
        Storage storage = (Storage)TargetList[0];
        if (RequestTrigger.IsTriggered(storage, RequireValue))
        {
            Status = EffectStatus.Activated;
        }
    }

    public new void Execute(Queue<Effect> pendingEffectQueue)
    {
        pendingEffectQueue.Enqueue((Effect)Value);
        Status = EffectStatus.Finished;
    }
}
