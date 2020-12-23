using System.Collections.Generic;

public class SpawnEffect : Effect
{
    public const string TYPE = "spawn";

    public SpawnEffect(Model source, Coordinate coordinate, object value) : base(source, coordinate, TYPE, value)
    {
    }

    public override void Activate(Model target)
    {
        throw new System.NotImplementedException();
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        throw new System.NotImplementedException();
    }

    public override Effect Clone()
    {
        throw new System.NotImplementedException();
    }
}
