public class TargetTrigger : Trigger
{
    public const string TYPE = "target";

    public TargetTrigger(Model source, Model target, Effect baseEffect, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, offset)
    {
        BaseEffect = baseEffect.Bind(target);
        BaseEffect.Trigger = this;
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
        Effect effectWithTarget = BaseEffect;
        return model.GetHashCode().Equals(effectWithTarget.TargetModel.GetHashCode());
    }
}
