using System.Collections.Generic;

public class SpawnEffect : Effect
{
    public const string TYPE = "spawn";

    public SpawnEffect(Model source, Model value, int offset) : base(source, value.CommonPropertySet.Coordinate, TYPE, value, offset)
    {
    }

    public override void Activate(Model target)
    {
        Status = EffectStatus.Activated;
    }

    public override void Execute()
    {
        Status = EffectStatus.Finished;
        ModelObserver.SpawnNewModel((Model)Value);
    }

    public override Effect Clone()
    {
        return new SpawnEffect(Source, (Model)Value, OffSet);
    }
}
