using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : Effect
{
    public const string TYPE = "move";

    public MoveEffect(Model source, Model target, Coordinate coordinateValue) : this(source, target.CommonPropertySet.Coordinate, coordinateValue)
    {
        TargetList.Add(target);
        Status = EffectStatus.Activated;
    }

    public MoveEffect(Model source, Coordinate coordinate, Coordinate coordinateValue) : base(source, coordinate, TYPE, coordinateValue)
    {
    }

    public override void Activate(Model target)
    {
        if (MoveTrigger.IsTriggered(target, this))
        {
            Status = EffectStatus.Activated;
            TargetList.Add(target);
        }
    }

    public override void Execute(Queue<Effect> pendingEffectQueue)
    {
        foreach (Model model in TargetList)
        {
            Coordinate moveCoordinateValue = (Coordinate)Value;
            model.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
            Debug.Log(model.GetType() + ", " + model.CommonPropertySet.Coordinate.ToString());
        }
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        if (Status == EffectStatus.Activated)
        {
            return new MoveEffect(Source, TargetList[0], (Coordinate)Value);
        }
        return new MoveEffect(Source, Coordinate, (Coordinate)Value);
    }
}
