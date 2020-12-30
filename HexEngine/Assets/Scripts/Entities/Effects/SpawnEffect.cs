using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : Effect
{
    public const string TYPE = "spawn";

    public SpawnEffect(Model source, Coordinate coordinate, object value) : base(source, coordinate, TYPE, value)
    {
    }

    public override void Activate(Model target)
    {
        Status = EffectStatus.Activated;
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        Status = EffectStatus.Finished;
        ModelObserver.SpawnNewModel((Model)Value);
    }

    public override Effect Clone()
    {
        throw new System.NotImplementedException();
    }
}
