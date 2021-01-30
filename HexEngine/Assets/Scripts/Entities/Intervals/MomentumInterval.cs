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
        ChainTrigger chainTrigger = new ChainTrigger(model, new ChainTrigger.ChainSet(GetMoveTrigger(model), GetCollisionTrigger(model), ChainTrigger.ChainSet.ChainType.Hook));
        QueueTrigger(chainTrigger);
    }

    private Trigger GetMoveTrigger(Model model)
    {
        MomentumPropertySet momentumPropertySet = model.CommonPropertySet.MomentumPropertySet;

        Coordinate.Vector vectorDirection = momentumPropertySet.GetVectorDirection(model.CommonPropertySet.Coordinate);
        Coordinate moveValueCoordinate = CoordinateUtil.GetCoordinate(vectorDirection);

        ModifyPropertyEffect modifyEffect = new ModifyPropertyEffect(new CoordinateModifier(moveValueCoordinate));
        //TODO replace offset with momentum calculated value
        return new TargetTrigger(model, model, modifyEffect, 2);
    }

    private Trigger GetCollisionTrigger(Model model)
    {
        //TODO replace damage value
        return new Trigger(model, model.CommonPropertySet.Coordinate, new ModifyPropertyEffect(new HpModifier(10)), 0);
    }
}
