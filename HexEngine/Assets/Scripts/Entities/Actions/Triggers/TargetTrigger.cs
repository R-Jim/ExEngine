public class TargetTrigger : Trigger
{
    public const string TYPE = "target";

    public TargetTrigger(Model source, Model target, Effect baseEffect, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, baseEffect, offset)
    {
        BaseEffect = baseEffect.Bind(target);
    }


    public override Effect Hook(Model model)
    {
        if (SameTarget(model))
        {
            return BaseEffect;
        }
        return null;
    }

    private bool SameTarget(Model model)
    {
        return model.GetHashCode().Equals(BaseEffect.TargetModel.GetHashCode());
    }
}
