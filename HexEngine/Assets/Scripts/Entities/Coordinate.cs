public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public Coordinate(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Coordinate()
    {

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
        Coordinate coordinate = (Coordinate) obj;
        return coordinate.X == X && coordinate.Y == Y && coordinate.Z == Z;
    }
}
