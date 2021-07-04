public class StoragePropertySet
{
    public string Type { get; }
    public int Max { get; }
    public int Current { get; private set; }

    public StoragePropertySet(int max) : this(max, max)
    {

    }

    public StoragePropertySet(int max, int current)
    {
        Max = max;
        Current = current;
    }

    public bool ClaimValue(int value)
    {
        if (Current - value >= 0)
        {
            Current -= value;
            return true;
        }
        return false;
    }

    public override string ToString()
    {
        return "(" + Max + "/" + Current + ")";
    }
}
