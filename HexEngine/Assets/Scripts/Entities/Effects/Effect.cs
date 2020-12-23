using System.Collections.Generic;

public abstract class Effect
{
    public EffectStatus Status { get; protected set; }
    public string Type { get; }
    public Coordinate Coordinate { get; }
    public Model Source;
    public List<Model> TargetList;
    public object Value;

    public Effect(Model source, Coordinate coordinate, string type, object value)
    {
        Source = source;
        Coordinate = coordinate;
        Type = type;
        Value = value;
        TargetList = new List<Model>();
    }

    public abstract void Activate(Model target);

    public abstract void Execute(Queue<Effect> pendingEffectQueue);

    public enum EffectStatus
    {
        Pending,
        Activated,
        Finished,
    }

    public abstract Effect Clone();
}