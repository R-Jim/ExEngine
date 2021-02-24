public class CoordinateModifier : Modifier
{
    public CoordinateModifier(Coordinate.Vector vectorValue) : base(vectorValue)
    {

    }

    public override void Modify(Effect effect)
    {
        Model targetModel = effect.TargetModel;
        Modify(targetModel, 0);
    }

    public float Modify(Model targetModel, float bonusImpactValue = 0)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(targetModel);
        float pushImpactValue = PushUtil.Push(upMostModel, this, bonusImpactValue);
        float remainImpactValue = pushImpactValue - CommonPropertySetUtil.GetFullWeight(upMostModel);
        if (remainImpactValue >= 0)
        {
            MoveModel(upMostModel);
        }
        targetModel.CommonPropertySet.SpeedAxisSet.ConsumeValueByDirection((Coordinate.Vector)Value);
        return remainImpactValue;
    }

    private void MoveModel(Model model)
    {
        Coordinate moveCoordinateValue = CoordinateUtil.GetCoordinate((Coordinate.Vector)Value);
        model.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
        MoveAllMountedModel(model);
    }

    private void MoveAllMountedModel(Model model)
    {
        if (model.MountPoints == null || model.MountPoints.Length == 0)
        {
            return;
        }

        foreach (MountPoint mountPoint in model.MountPoints)
        {
            if (mountPoint.MountedModel != null)
            {
                MoveModel(mountPoint.MountedModel);
            }
        }
    }
}
