public class TargetTrigger : Trigger
{
    public const string TYPE = "target";
    private Model Target;

    public TargetTrigger(Model source, Model target, Effect effect, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, effect, offset)
    {
        Target = target;
    }


    public override void Hook(BattleHandler battleHandler, Model model)
    {
        if (SameTarget(model))
        {
            HandleHookedModel(battleHandler, model);
        }
    }

    private bool SameTarget(Model model)
    {
        return Target.GetHashCode().Equals(model.GetHashCode());
    }
}
