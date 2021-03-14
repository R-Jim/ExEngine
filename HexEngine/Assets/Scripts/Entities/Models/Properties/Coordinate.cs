public class Coordinate
{
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public Vector Pivot { get; private set; }

    public Coordinate(float x, float y, float z, Vector pivot = Vector.XY)
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
        X += coordinate.X;
        Y += coordinate.Y;
        Z += coordinate.Z;
    }

    public void SetPivot(Vector vector)
    {
        Pivot = vector;
    }

    public void SetPivot(Coordinate coordinate)
    {
        Pivot = GetVector(coordinate);
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


    public Vector GetVector(Coordinate coordinate)
    {
        float x = X - coordinate.X;
        float y = Y - coordinate.Y;
        float z = Z - coordinate.Z;

        if (x == 0)
        {
            if (y > 0)
            {
                return Vector.YZ;
            }
            return Vector.ZY;
        }
        else if (y == 0)
        {
            if (z > 0)
            {
                return Vector.ZX;
            }
            return Vector.XZ;
        }
        if (x > 0)
        {
            return Vector.XY;
        }
        return Vector.YX;
    }

    public enum Vector
    {
        XY,
        YX,
        XZ,
        ZX,
        YZ,
        ZY,
    }
}
