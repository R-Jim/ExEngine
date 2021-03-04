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

        MomentumAxisSet momentumAxisSet = momentumPropertySet.GetMomentumAxisSet(model.CommonPropertySet.Coordinate);
        Coordinate.Vector vectorDirection = momentumAxisSet.GetVectorDirection(momentumAxisSet.Value);

        momentumPropertySet.ConsumeMomentum(vectorDirection);
        model.CommonPropertySet.SpeedAxisSet = momentumAxisSet;

        ModifyPropertyEffect modifyEffect = new ModifyPropertyEffect(new CoordinateModifier(vectorDirection))
        {
            PostEffect = (effect) =>
            {
                effect.TargetModel.CommonPropertySet.SpeedAxisSet.ConsumeValueByDirection((Coordinate.Vector)effect.Value);
            }
        };
        //TODO replace offset with momentum calculated value
        return new TargetTrigger(model, model, modifyEffect, 1);
    }
}
