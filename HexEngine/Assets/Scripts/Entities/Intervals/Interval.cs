public abstract class Interval
{
    public int TickInterval { get; }
    public BattleHandler BattleHandler { get; }

    protected Interval(int tickInterval, BattleHandler battleHandler)
    {
        TickInterval = tickInterval;
        BattleHandler = battleHandler;
    }

    public void Run(int tick)
    {
        if (!IsMatchInterval(tick))
        {
            return;
        }
        Process();
    }

    protected virtual void Process()
    {

    }

    protected void AddTrigger(Trigger trigger)
    {
        BattleHandler.AddTrigger(trigger);
    }

    private bool IsMatchInterval(int tick)
    {
        return tick % TickInterval == 0;
    }
}
