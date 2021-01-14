using System.Collections.Generic;

public abstract class Effect
{
    public EffectStatus Status { get; protected set; }
    public string Type { get; }
    public Coordinate Coordinate { get; }
    public Model Source;
    public List<Model> TargetList;
    public object Value;
    public int OffSet { get; }
    public int EnqueueTick { get; set; }

    public Effect(Model source, Coordinate coordinate, string type, object value, int offset = 0)
    {
        Source = source;
        Coordinate = coordinate;
        Type = type;
        Value = value;
        TargetList = new List<Model>();
        Status = EffectStatus.Pending;
        OffSet = offset;
        EnqueueTick = 0;
    }

    public abstract void Activate(Model target);

    public abstract void Execute();

    public enum EffectStatus
    {
        Pending,
        Activated,
        Finished,
    }

    public abstract Effect Clone();
}