public class TargetTrigger : Trigger
{
    public const string TYPE = "target";

    public TargetTrigger(Model source, Model target, Effect baseEffect, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, offset)
    {
        BaseEffect = new Effect(this, baseEffect.Bind(target));
    }


    public override Effect Hook(Model model)
    {
        if (SameTarget(model))
        {
            return (Effect)BaseEffect.Value;
        }
        return null;
    }

    private bool SameTarget(Model model)
    {
        Effect effectWithTarget = (Effect)BaseEffect.Value;
        return model.GetHashCode().Equals(effectWithTarget.TargetModel.GetHashCode());
    }
}
