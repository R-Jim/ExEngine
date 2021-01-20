public class MoveTrigger : Trigger
{
    public const string TYPE = "move";

    public MoveTrigger(Model source, Coordinate triggerCoordinate, Coordinate moveValue, int offset)
        : base(source, TYPE, triggerCoordinate, offset)
    {
        BaseEffect = new MoveEffect(this, moveValue);
    }


    public override Effect Hook(Model model)
    {
        if (SameCoordinate(model))
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }

    private bool SameCoordinate(Model model)
    {
        return model.CommonPropertySet.Coordinate.Equals(TriggerCoordinate);
    }
}
