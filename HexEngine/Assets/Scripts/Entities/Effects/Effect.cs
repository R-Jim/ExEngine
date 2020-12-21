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

    public void Activate(Model target)
    {
        Status = EffectStatus.Activated;
    }

    public void Execute(Queue<Effect> pendingEffectQueue)
    {

    }

    public enum EffectStatus
    {
        Pending,
        Activated,
        Executing,
        Finished,
    }
}