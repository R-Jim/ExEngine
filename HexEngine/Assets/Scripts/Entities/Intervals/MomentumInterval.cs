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

        Coordinate.VectorDirection vectorDirection = momentumPropertySet.GetVectorDirection(model.CommonPropertySet.Coordinate);
        Coordinate moveValueCoordinate = CoordinateUtil.GetCoordinate(vectorDirection);

        MoveEffect moveEffect = new MoveEffect(new Trigger(), moveValueCoordinate);
        TargetTrigger targetTrigger = new TargetTrigger(model, model, moveEffect, 2);
        CollisionTrigger collisionTrigger = new CollisionTrigger(model, model.CommonPropertySet.Coordinate, 10, 0);

        ChainTrigger chainTrigger = new ChainTrigger(model, new ChainTrigger.ChainSet(targetTrigger, collisionTrigger, ChainTrigger.ChainSet.ChainType.Hook));
        QueueTrigger(chainTrigger);
    }
}
