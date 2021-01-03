public class CoordinateUtil
{
    public static Coordinate GetCoordinate(MomentumStorage.Axis axis, int multiplier = 1)
    {
        return new Coordinate(XPreset(axis, multiplier), YPreset(axis, multiplier), ZPreset(axis, multiplier));
    }

    private static int XPreset(MomentumStorage.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.XY:
            case MomentumStorage.Axis.XZ: return 1 * multiplier;
            case MomentumStorage.Axis.YX:
            case MomentumStorage.Axis.ZX: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int YPreset(MomentumStorage.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.YX:
            case MomentumStorage.Axis.YZ: return 1 * multiplier;
            case MomentumStorage.Axis.XY:
            case MomentumStorage.Axis.ZY: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int ZPreset(MomentumStorage.Axis moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.ZX:
            case MomentumStorage.Axis.ZY: return 1 * multiplier;
            case MomentumStorage.Axis.XZ:
            case MomentumStorage.Axis.YZ: return -1 * multiplier;
            default: return 0;
        }
    }
}
