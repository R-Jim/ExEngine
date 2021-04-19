public class MomentumInterval : Interval
{
    public MomentumInterval(BattleHandler battleHandler) : base(1, battleHandler)
    {

    }

    protected override void Process()
    {
        foreach (Model model in BattleHandler.GetModels())
        {
            MomentumPropertySet momentumPropertySet = model.CommonPropertySet.MomentumPropertySet;
            if (momentumPropertySet.IsEmpty())
            {
                continue;
            }
            AddTrigger(GetMoveTrigger(model));
        }
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
        return new TargetTrigger(model, model, modifyEffect, 0);
    }
}
