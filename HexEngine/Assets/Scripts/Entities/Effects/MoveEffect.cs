using System.Collections.Generic;

public class MoveEffect : Effect
{
    public const string TYPE = "move";

    public MoveEffect(Model source, Coordinate coordinate, Coordinate coordinateValue) : base(source, coordinate, TYPE, coordinateValue)
    {
    }

    new public void Activate(Model target)
    {
        if (MoveTrigger.IsTriggered(target, this))
        {
            Status = EffectStatus.Activated;
            TargetList.Add(target);
        }
    }

    new public void Execute(Queue<Effect> pendingEffectQueue)
    {
        foreach (Model model in TargetList)
        {
            Coordinate moveCoordinateValue = (Coordinate)Value;
            model.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
        }
        Status = EffectStatus.Finished;
    }
}
