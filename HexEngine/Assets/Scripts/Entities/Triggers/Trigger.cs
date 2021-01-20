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

    //Placeholder
    public Trigger() : this(null, null, null)
    {

    }

    protected Trigger(Model source, string type, Coordinate triggerCoordinate, int offset = 0)
    {
        Source = source;
        Type = type;
        TriggerCoordinate = triggerCoordinate;
        OffSet = offset;
        ExecutedModel = new HashSet<Model>();
    }

    public virtual Effect Hook(Model model)
    {
        if (BaseEffect != null)
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }

    public virtual void Reset()
    {
        ExecutedModel = new HashSet<Model>();
    }
}
