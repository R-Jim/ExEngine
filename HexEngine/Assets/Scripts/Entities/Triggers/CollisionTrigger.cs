using System.Diagnostics;

public class CollisionTrigger : Trigger
{
    public const string TYPE = "collision";

    public CollisionTrigger(Model source, Coordinate triggerCoordinate, int damageValue, int offset)
        : base(source, TYPE, triggerCoordinate, offset)
    {
        BaseEffect = new CollisionEffect(this, damageValue);
    }


    public override Effect Hook(Model model)
    {
        if (SameCoordinate(model) && DifferentModel(model))
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }

    private bool DifferentModel(Model model)
    {
        return model.GetHashCode() != Source.GetHashCode();
    }

    private bool SameCoordinate(Model model)
    {
        return model.CommonPropertySet.Coordinate.Equals(TriggerCoordinate);
    }
}
