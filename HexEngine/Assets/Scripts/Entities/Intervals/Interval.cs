public abstract class Interval
{
    public int TickInterval { get; }

    protected Interval(int tickInterval)
    {
        TickInterval = tickInterval;
    }

    public void Run(int tick, Model model)
    {
        if (!IsMatchInterval(tick))
        {
            return;
        }
        Process(model);
    }

    protected virtual void Process(Model model)
    {

    }

    protected void QueueTrigger(Trigger trigger)
    {
        TriggerContainer.QueueTrigger(trigger);
    }

    private bool IsMatchInterval(int tick)
    {
        return tick % TickInterval == 0;
    }
}
