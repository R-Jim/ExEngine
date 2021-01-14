public class CoordinateUtil
{
    public static Coordinate GetCoordinate(Coordinate.Axis axis, int multiplier = 1)
    {
        return new Coordinate(XPreset(axis, multiplier), YPreset(axis, multiplier), ZPreset(axis, multiplier));
    }

    private static int XPreset(Coordinate.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.Axis.XY:
            case Coordinate.Axis.XZ: return 1 * multiplier;
            case Coordinate.Axis.YX:
            case Coordinate.Axis.ZX: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int YPreset(Coordinate.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.Axis.YX:
            case Coordinate.Axis.YZ: return 1 * multiplier;
            case Coordinate.Axis.XY:
            case Coordinate.Axis.ZY: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int ZPreset(Coordinate.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.Axis.ZX:
            case Coordinate.Axis.ZY: return 1 * multiplier;
            case Coordinate.Axis.XZ:
            case Coordinate.Axis.YZ: return -1 * multiplier;
            default: return 0;
        }
    }
}
