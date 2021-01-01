public class CollisionTrigger
{
    public static bool IsTriggered(Model model, Effect effect)
    {
        return DifferentModel(model, effect) && SameCoordinate(model.CommonPropertySet.Coordinate, effect);
    }

    private static bool DifferentModel(Model model, Effect effect)
    {
        return model.GetHashCode() != effect.Source.GetHashCode();
    }

    private static bool SameCoordinate(Coordinate coordinate, Effect effect)
    {
        return coordinate.Equals(effect.Coordinate);
    }
}
