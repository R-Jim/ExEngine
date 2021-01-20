public class Coordinate
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }

    public Coordinate(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Coordinate()
    {

    }

    public void To(Coordinate coordinate)
    {
        X = coordinate.X;
        Y = coordinate.Y;
        Z = coordinate.Z;
    }

    public void Add(Coordinate coordinate)
    {
        X += coordinate.X;
        Y += coordinate.Y;
        Z += coordinate.Z;
    }

    public void Multiply(Coordinate coordinate)
    {
        X *= coordinate.X;
        Y *= coordinate.Y;
        Z *= coordinate.Z;
    }


    public new string ToString()
    {
        return "X:" + X + ", Y:" + Y + ", Z:" + Z;
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
        return new Coordinate(X, Y, Z);
    }

    public enum Axis
    {
        XY,
        YX,
        XZ,
        ZX,
        YZ,
        ZY,
    }
}
