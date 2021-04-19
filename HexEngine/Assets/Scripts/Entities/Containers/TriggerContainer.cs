using System.Collections.Generic;

public class TriggerContainer
{
    private readonly List<Trigger> TriggerList = new List<Trigger>();

    private readonly BattleHandler BattleHandler;

    public TriggerContainer(BattleHandler battleHandler)
    {
        BattleHandler = battleHandler;
    }

    public Trigger GetTrigger()
    {
        int index = TriggerList.FindIndex(trigger => trigger.EnqueueTick + trigger.OffSet == BattleHandler.GetSystemTick());
        if (index == -1)
        {
            return null;
        }
        Trigger returnTrigger = TriggerList[index];
        TriggerList.RemoveAt(index);
        return returnTrigger;
    }

    public void AddTrigger(Trigger trigger)
    {
        trigger.EnqueueTick = BattleHandler.GetSystemTick();
        TriggerList.Add(trigger);
    }
}
