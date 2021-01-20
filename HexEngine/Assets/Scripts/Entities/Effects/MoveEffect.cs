using UnityEngine;

public class MoveEffect : Effect
{
    public MoveEffect(Trigger trigger, Coordinate moveValue) : base(trigger, moveValue)
    {
    }

    public override void Execute()
    {
        //if (IsMoved(TargetModel))
        //{
        //    return;
        //}
        Model model = GetUpMostModel(TargetModel);
        MoveModel(model);
        Status = EffectStatus.Executed;
        AssignEffectAfterExecuted();
    }

    private void MoveModel(Model model)
    {
        Coordinate moveCoordinateValue = (Coordinate)Value;
        model.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
        LogMovedModel(model);
        Debug.LogWarning(TargetModel.GetType() + ", " + TargetModel.CommonPropertySet.Coordinate.ToString());
        MoveAllMountedModel(model);
    }

    private bool IsMoved(Model model)
    {
        return Trigger.ExecutedModel.Contains(model);
    }

    private void LogMovedModel(Model model)
    {
        Trigger.ExecutedModel.Add(model);
    }

    private void MoveAllMountedModel(Model model)
    {
        if (model.MountPoints != null && model.MountPoints.Length != 0)
        {
            foreach (MountPoint mountPoint in model.MountPoints)
            {
                if (mountPoint.MountedModel != null)
                {
                    MoveModel(mountPoint.MountedModel);
                }
            }

        }
    }

    private Model GetUpMostModel(Model model)
    {
        MountPoint mountPoint = model.CommonPropertySet.MountedTo;
        if (mountPoint != null)
        {
            return GetUpMostModel(mountPoint.SourceModel);
        }
        return model;
    }

    public override Effect Bind(Model model)
    {
        Effect effect = new MoveEffect(Trigger, (Coordinate)Value)
        {
            TargetModel = model
        };
        return effect;
    }
}
