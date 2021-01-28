using System.Collections.Generic;

public class Trigger
{
    public Model Source { get; }
    public string Type { get; }
    public Coordinate TriggerCoordinate { get; }
    public Effect BaseEffect { get; protected set; }
    public int OffSet { get; }
    public int EnqueueTick { get; set; }

    public HashSet<Model> ExecutedModel { get; protected set; }

    public Trigger(Model source, Coordinate triggerCoordinate, Effect baseEffect, int offset = 0) : this(source, "trigger", triggerCoordinate, baseEffect, offset)
    {

    }

    protected Trigger(Model source, string type, Coordinate triggerCoordinate, Effect baseEffect, int offset = 0)
    {
        Source = source;
        Type = type;
        TriggerCoordinate = triggerCoordinate;
        BaseEffect = baseEffect;
        BaseEffect.Trigger = this;
        OffSet = offset;
        ExecutedModel = new HashSet<Model>();
    }

    public virtual Effect Hook(Model model)
    {
        if (SameCoordinate(model))
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }

    private bool SameCoordinate(Model model)
    {
        return model.CommonPropertySet.Coordinate.Equals(TriggerCoordinate);
    }

    public virtual void Reset()
    {
        ExecutedModel = new HashSet<Model>();
    }
}
