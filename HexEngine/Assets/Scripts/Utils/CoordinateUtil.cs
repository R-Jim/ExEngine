public class CoordinateUtil
{
    public static Coordinate GetCoordinate(MomentumStorage.Axis axis)
    {
        return new Coordinate(XPreset(axis), YPreset(axis), ZPreset(axis));
    }

    private static int XPreset(MomentumStorage.Axis moveAxisPreset)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.XY:
            case MomentumStorage.Axis.XZ: return 1;
            case MomentumStorage.Axis.YX:
            case MomentumStorage.Axis.ZX: return -1;
            default: return 0;
        }
    }

    private static int YPreset(MomentumStorage.Axis moveAxisPreset)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.YX:
            case MomentumStorage.Axis.YZ: return 1;
            case MomentumStorage.Axis.XY:
            case MomentumStorage.Axis.ZY: return -1;
            default: return 0;
        }
    }

    private static int ZPreset(MomentumStorage.Axis moveAxisPreset)
    {
        switch (moveAxisPreset)
        {
            case MomentumStorage.Axis.ZX:
            case MomentumStorage.Axis.ZY: return 1;
            case MomentumStorage.Axis.XZ:
            case MomentumStorage.Axis.YZ: return -1;
            default: return 0;
        }
    }
}
