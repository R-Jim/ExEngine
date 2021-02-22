class MomentumInterval : Interval
{
    public MomentumInterval() : base(1)
    {

    }

    protected override void Process(Model model)
    {
        MomentumPropertySet momentumPropertySet = model.CommonPropertySet.MomentumPropertySet;
        if (momentumPropertySet.IsEmpty())
        {
            return;
        }
        QueueTrigger(GetMoveTrigger(model));
    }

    private Trigger GetMoveTrigger(Model model)
    {
        MomentumPropertySet momentumPropertySet = model.CommonPropertySet.MomentumPropertySet;

        Coordinate.Vector vectorDirection = momentumPropertySet.GetVectorDirection(model.CommonPropertySet.Coordinate);
        momentumPropertySet.ConsumeMomentum(vectorDirection);

        ModifyPropertyEffect modifyEffect = new ModifyPropertyEffect(new CoordinateModifier(vectorDirection));
        //TODO replace offset with momentum calculated value
        return new TargetTrigger(model, model, modifyEffect, 1);
    }
}
