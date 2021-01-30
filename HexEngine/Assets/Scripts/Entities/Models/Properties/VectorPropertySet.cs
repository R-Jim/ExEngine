public class VectorPropertySet
{
    public Coordinate.Vector Vector { get; }
    public int Multiplier { get; }

    public VectorPropertySet(Coordinate.Vector vector, int multiplier = 1)
    {
        Vector = vector;
        Multiplier = multiplier;
    }
}
