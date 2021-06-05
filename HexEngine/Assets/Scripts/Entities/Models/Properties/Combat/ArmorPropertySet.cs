public class ArmorPropertySet
{
    public int Value { get; }
    public float Nullifier { get; }
    public int Absorption { get; }

    public ArmorPropertySet(int value, float nullifier, int absorption)
    {
        Value = value;
        Nullifier = nullifier;
        Absorption = absorption;
    }
}
