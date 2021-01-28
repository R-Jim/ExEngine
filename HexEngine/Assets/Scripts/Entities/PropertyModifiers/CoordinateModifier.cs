class CoordinateModifier : Modifier
{
    public CoordinateModifier(Coordinate moveValue) : base(moveValue)
    {

    }

    public override void Modify(Effect effect)
    {
        Coordinate moveCoordinateValue = (Coordinate)Value;
        effect.TargetModel.CommonPropertySet.Coordinate.Add(moveCoordinateValue);
    }
}
