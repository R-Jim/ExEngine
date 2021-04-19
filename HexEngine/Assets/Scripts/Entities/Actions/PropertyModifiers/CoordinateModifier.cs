public class CoordinateModifier : Modifier
{
    public CoordinateModifier(Coordinate.Vector vectorValue) : base(vectorValue)
    {

    }

    public override void Modify(Effect effect, BattleHandler battleHandler)
    {
        Modify(effect.TargetModel, battleHandler, 0);
    }

    public float Modify(Model targetModel, BattleHandler battleHandler, float bonusImpactValue = 0)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(targetModel);
        float pushImpactValue = PushUtil.Push(upMostModel, this, bonusImpactValue, battleHandler);
        float remainImpactValue = pushImpactValue - CommonPropertySetUtil.GetFullWeight(upMostModel);
        if (remainImpactValue >= 0)
        {
            MoveModel(upMostModel);
        }
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
