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

        Coordinate.Vector vectorDirection = momentumPropertySet.GetVectorDirection(model.CommonPropertySet.Coordinate);
        Coordinate moveValueCoordinate = CoordinateUtil.GetCoordinate(vectorDirection);

        ModifyPropertyEffect modifyEffect = new ModifyPropertyEffect(new CoordinateModifier(moveValueCoordinate));
        TargetTrigger targetTrigger = new TargetTrigger(model, model, modifyEffect, 2);

        Trigger collisionTrigger = new Trigger(model, model.CommonPropertySet.Coordinate, new ModifyPropertyEffect(new HpModifier(10)), 0);

        ChainTrigger chainTrigger = new ChainTrigger(model, new ChainTrigger.ChainSet(targetTrigger, collisionTrigger, ChainTrigger.ChainSet.ChainType.Hook));
        QueueTrigger(chainTrigger);
    }
}
