using System.Collections.Generic;

public class Trigger
{
    public Model Source { get; }
    public string Type { get; }
    public Coordinate TriggerCoordinate { get; }
    public Effect Effect { get; protected set; }
    public int OffSet { get; }
    public int EnqueueTick { get; set; }

    public HashSet<Model> HookedModel { get; protected set; }

    public Trigger(Model source, Coordinate triggerCoordinate, Effect effect, int offset = 0) : this(source, "trigger", triggerCoordinate, effect, offset)
    {

    }

    protected Trigger(Model source, string type, Coordinate triggerCoordinate, Effect effect, int offset = 0)
    {
        Source = source;
        Type = type;
        TriggerCoordinate = triggerCoordinate;
        Effect = effect;
        if (effect != null)
        {
            Effect.SetUp(this, null);
        }
        OffSet = offset;
        HookedModel = new HashSet<Model>();
    }

    public virtual void Hook(BattleHandler battleHandler, Model model)
    {
        if (SameCoordinate(model))
        {
            HandleHookedModel(battleHandler, model);
        }
    }

    protected void HandleHookedModel(BattleHandler battleHandler, Model model)
    {
        HookedModel.Add(model);
        Effect.Execute(battleHandler, model);
        EventHandling(model);
    }

    protected void EventHandling(Model model)
    {
        LoggingEvent loggingEvent = new LoggingEvent(this, model);
        model.AddEvent(loggingEvent);
        Source.AddEvent(loggingEvent);
    }

    private bool SameCoordinate(Model model)
    {
        return model.CommonPropertySet.Coordinate.Equals(TriggerCoordinate);
    }
}
