using System;
using System.Collections.Generic;

public class Model
{
    public CommonPropertySet CommonPropertySet { get; }
    public CombatPropertySet CombatPropertySet { get; }
    public GameObjectPropertySet GameObjectPropertySet { get; }
    public MountPoint[] MountPoints;

    //For animation
    private Queue<LoggingEvent> EventQueue = new Queue<LoggingEvent>();

    public Model(CommonPropertySet commonPropertySet, CombatPropertySet combatPropertySet, GameObjectPropertySet gameObjectPropertySet, MountPoint[] mountPoints)
    {
        CommonPropertySet = commonPropertySet;
        CombatPropertySet = combatPropertySet ?? new CombatPropertySet();
        GameObjectPropertySet = gameObjectPropertySet;
        MountPoints = mountPoints;
        if (MountPoints != null)
        {
            foreach (MountPoint mountPoint in MountPoints)
            {
                mountPoint.SourceModel = this;
            }
        }
    }

    public void AddEvent(LoggingEvent loggingEvent)
    {
        if (loggingEvent.IsSource(this) || loggingEvent.IsTarget(this))
        {
            EventQueue.Enqueue(loggingEvent);
            return;
        }
        throw new Exception(GetHashCode() + "#Model is not related to the logging event(" + loggingEvent.SourceHashCode + "," + loggingEvent.TargetHashCode + ")");
    }

    public LoggingEvent GetEvent()
    {
        if (EventQueue.Count == 0)
        {
            return null;
        }
        return EventQueue.Dequeue();
    }

    public virtual bool IsRemovable()
    {
        return CommonPropertySet.HpStorage.IsEmpty();
    }
}
