public class CoordinateUtil
{
    public static Coordinate GetCoordinate(Coordinate coordinate, Coordinate.Vector vectorDirection, int multiplier = 1)
    {
        Coordinate returnCoordinate = coordinate.Clone();
        returnCoordinate.Add(GetCoordinate(vectorDirection, multiplier));
        return returnCoordinate;
    }

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

    public static Coordinate.Vector AdjustVector(Coordinate.Vector modelFacingDirection, Coordinate.Vector vector)
    {
        Coordinate.Vector adjustedVector = (int)vector - modelFacingDirection;
        if (adjustedVector < 0)
        {
            adjustedVector += 6;
        }
        return adjustedVector;
    }

    public static Coordinate.Vector RevertVector(Coordinate.Vector vector)
    {
        Coordinate.Vector revertedVector = vector - 3;
        if (revertedVector < 0)
        {
            revertedVector += 6;
        }
        return revertedVector;
    }
}
