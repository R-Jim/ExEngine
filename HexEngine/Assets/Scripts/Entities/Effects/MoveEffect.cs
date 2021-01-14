using System.Collections.Generic;
using UnityEngine;

public class MoveEffect : Effect
{
    public const string TYPE = "move";

    public MoveEffect(Model source, Model target, Coordinate coordinateValue, int offset) : this(source, target.CommonPropertySet.Coordinate, coordinateValue, offset)
    {
        TargetList.Add(target);
        Status = EffectStatus.Activated;
    }

    public MoveEffect(Model source, Coordinate coordinate, Coordinate coordinateValue, int offset) : base(source, coordinate, TYPE, coordinateValue, offset)
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

    public override void Execute()
    {
        foreach (Model model in TargetList)
        {
            Coordinate moveCoordinateValue = (Coordinate)Value;
            model.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
            Debug.LogWarning(model.GetType() + ", " + model.CommonPropertySet.Coordinate.ToString());
        }
        Status = EffectStatus.Finished;
    }

    public override Effect Clone()
    {
        if (Status == EffectStatus.Activated)
        {
            return new MoveEffect(Source, TargetList[0], (Coordinate)Value, OffSet);
        }
        return new MoveEffect(Source, Coordinate, (Coordinate)Value, OffSet);
    }
}
