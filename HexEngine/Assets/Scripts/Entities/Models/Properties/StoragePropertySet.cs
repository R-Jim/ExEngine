public class StoragePropertySet
{
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

    public int Get(int value)
    {
        if (Current >= value)
        {
            return value;
        }
        else
        {
            return 0;
        }
    }

    public void Fill(int value)
    {
        Current += value;
        if (Current > Max)
        {
            Current = Max;
        }
        else if (Current <= 0)
        {
            Current = 0;
        }
    }

    public bool IsEmpty()
    {
        return Current <= 0;
    }

    public override string ToString()
    {
        return "(" + Max + "/" + Current + ")";
    }
}
