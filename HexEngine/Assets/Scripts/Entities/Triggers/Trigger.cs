using System.Collections.Generic;

public class Trigger
{
    public Model Source { get; }
    public string Type { get; }
    public Coordinate TriggerCoordinate { get; }
    public Effect BaseEffect { get; protected set; }
    public int OffSet { get; }
    public int EnqueueTick { get; set; }

    public readonly HashSet<Model> ExecutedModel = new HashSet<Model>();

    //Placeholder
    public Trigger()
    {

    }

    protected Trigger(Model source, string type, Coordinate triggerCoordinate, int offset = 0)
    {
        Source = source;
        Type = type;
        TriggerCoordinate = triggerCoordinate;
        OffSet = offset;
    }

    public virtual Effect Hook(Model model)
    {
        if (BaseEffect != null)
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }
}
