public class CoordinateUtil
{
    public static Coordinate GetCoordinate(Coordinate.VectorDirection vectorDirection, int multiplier = 1)
    {
        return new Coordinate(XPreset(vectorDirection, multiplier), YPreset(vectorDirection, multiplier), ZPreset(vectorDirection, multiplier), vectorDirection);
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
