using System.Collections.Generic;

public class RequestEffect : Effect
{
    public const string TYPE = "request";

    public RequestEffect(Model source, Storage storage, int requireValue, int offset) : base(source, null, TYPE, requireValue, offset)
    {
        TargetList.Add(storage);
    }

    public override void Activate(Model unusedModel)
    {
        Storage storage = (Storage)TargetList[0];
        if (RequestTrigger.IsTriggered(storage, (int)Value))
        {
            Status = EffectStatus.Activated;
        }
    }

    public override void Execute()
    {
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        return new RequestEffect(Source, (Storage)TargetList[0], (int)Value, OffSet);
    }
}
