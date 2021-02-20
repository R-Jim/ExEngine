public class CoordinateUtil
{
    public static Coordinate GetCoordinate(Coordinate.Vector vectorDirection, int multiplier = 1)
    {
        return new Coordinate(XPreset(vectorDirection, multiplier), YPreset(vectorDirection, multiplier), ZPreset(vectorDirection, multiplier), vectorDirection);
    }

    private static int XPreset(Coordinate.Vector vector, int multiplier = 1)
    {
        switch (vector)
        {
            case Coordinate.Vector.XY:
            case Coordinate.Vector.XZ: return 1 * multiplier;
            case Coordinate.Vector.YX:
            case Coordinate.Vector.ZX: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int YPreset(Coordinate.Vector vector, int multiplier = 1)
    {
        switch (vector)
        {
            case Coordinate.Vector.YX:
            case Coordinate.Vector.YZ: return 1 * multiplier;
            case Coordinate.Vector.XY:
            case Coordinate.Vector.ZY: return -1 * multiplier;
            default: return 0;
        }
    }

    private static int ZPreset(Coordinate.Vector vector, int multiplier = 1)
    {
        switch (vector)
        {
            case Coordinate.Vector.ZX:
            case Coordinate.Vector.ZY: return 1 * multiplier;
            case Coordinate.Vector.XZ:
            case Coordinate.Vector.YZ: return -1 * multiplier;
            default: return 0;
        }
    }

    public static Coordinate.Vector GetAxis(Coordinate baseCoordinate, Coordinate compareCoordinate)
    {
        float x = baseCoordinate.X - compareCoordinate.X;
        float y = baseCoordinate.Y - compareCoordinate.Y;
        float z = baseCoordinate.Z - compareCoordinate.Z;

        if (x == 0)
        {
            if (y > 0)
            {
                return Coordinate.Vector.YZ;
            }
            return Coordinate.Vector.ZY;
        }
        else if (y == 0)
        {
            if (z > 0)
            {
                return Coordinate.Vector.ZX;
            }
            return Coordinate.Vector.XZ;
        }
        if (x > 0)
        {
            return Coordinate.Vector.XY;
        }
        return Coordinate.Vector.YX;
    }
}
