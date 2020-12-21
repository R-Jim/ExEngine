public class MoveTrigger
{
    public static bool IsTriggered(Model model, Effect effect)
    {
        return SameCoordinate(model.CommonPropertySet.Coordinate, effect);
    }

    private static bool SameCoordinate(Coordinate coordinate, Effect effect)
    {
        return coordinate.Equals(effect.Coordinate);
    }
}
