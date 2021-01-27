public class Coordinate
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public VectorDirection Pivot { get; private set; }

    public Coordinate(float x, float y, float z, VectorDirection pivot = VectorDirection.XY)
    {
        X = x;
        Y = y;
        Z = z;
        Pivot = pivot;
    }

    public void To(Coordinate coordinate)
    {
        X = coordinate.X;
        Y = coordinate.Y;
        Z = coordinate.Z;
    }

    public void Add(Coordinate coordinate)
    {
        Coordinate oldCoordinate = Clone();
        X += coordinate.X;
        Y += coordinate.Y;
        Z += coordinate.Z;
        Pivot = CoordinateUtil.GetAxis(this, oldCoordinate);
    }

    public void Multiply(Coordinate coordinate)
    {
        X *= coordinate.X;
        Y *= coordinate.Y;
        Z *= coordinate.Z;
    }


    public new string ToString()
    {
        return "X:" + X + ", Y:" + Y + ", Z:" + Z + ", Pivot:" + Pivot;
    }

    public new bool Equals(object obj)
    {
        if (obj.GetType() != this.GetType())
        {
            return false;
        }
        Coordinate coordinate = (Coordinate)obj;
        return coordinate.X == X && coordinate.Y == Y && coordinate.Z == Z;
    }

    public Coordinate Clone()
    {
        return new Coordinate(X, Y, Z, Pivot);
    }

    public enum VectorDirection
    {
        XY,
        YX,
        XZ,
        ZX,
        YZ,
        ZY,
    }
}
