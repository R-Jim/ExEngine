public class CoordinateModifier : Modifier
{
    public CoordinateModifier(Coordinate.Vector vectorValue) : base(vectorValue)
    {

    }

    public override void Modify(Effect effect)
    {
        Model targetModel = effect.TargetModel;
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(targetModel);
        if (PushUtil.Push(upMostModel, this))
        {
            MoveModel(upMostModel);
        }
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
