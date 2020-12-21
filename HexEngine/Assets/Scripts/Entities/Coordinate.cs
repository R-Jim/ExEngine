public class Coordinate
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

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
}
