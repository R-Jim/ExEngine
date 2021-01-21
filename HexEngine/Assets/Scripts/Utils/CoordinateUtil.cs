public class CoordinateUtil
{
    public static Coordinate GetCoordinate(Coordinate.VectorDirection axis, int multiplier = 1)
    {
        return new Coordinate(XPreset(axis, multiplier), YPreset(axis, multiplier), ZPreset(axis, multiplier));
    }

    private static int XPreset(Coordinate.VectorDirection moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.VectorDirection.XY:
            case Coordinate.VectorDirection.XZ: return 1 * multiplier;
            case Coordinate.VectorDirection.YX:
            case Coordinate.VectorDirection.ZX: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int YPreset(Coordinate.VectorDirection moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.VectorDirection.YX:
            case Coordinate.VectorDirection.YZ: return 1 * multiplier;
            case Coordinate.VectorDirection.XY:
            case Coordinate.VectorDirection.ZY: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int ZPreset(Coordinate.VectorDirection moveAxisPreset, int multiplier = 1)
    {
        switch (moveAxisPreset)
        {
            case Coordinate.VectorDirection.ZX:
            case Coordinate.VectorDirection.ZY: return 1 * multiplier;
            case Coordinate.VectorDirection.XZ:
            case Coordinate.VectorDirection.YZ: return -1 * multiplier;
            default: return 0;
        }
    }

    public static Coordinate.VectorDirection GetAxis(Coordinate baseCoordinate, Coordinate compareCoordinate)
    {
        float x = baseCoordinate.X - compareCoordinate.X;
        float y = baseCoordinate.Y - compareCoordinate.Y;
        float z = baseCoordinate.Z - compareCoordinate.Z;

        if (x == 0)
        {
            if (y > 0)
            {
                return Coordinate.VectorDirection.YZ;
            }
            return Coordinate.VectorDirection.ZY;
        }
        else if (y == 0)
        {
            if (z > 0)
            {
                return Coordinate.VectorDirection.ZX;
            }
            return Coordinate.VectorDirection.XZ;
        }
        if (x > 0)
        {
            return Coordinate.VectorDirection.XY;
        }
        return Coordinate.VectorDirection.YX;
    }
}
