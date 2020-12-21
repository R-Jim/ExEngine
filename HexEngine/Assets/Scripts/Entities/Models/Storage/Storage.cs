public class Storage : Model
{
    public int Max { get; }
    public int Current { get; private set; }

    public Storage(int max) : this(max, 0)
    {

    }

    public Storage(int max, int current)
    {
        Max = max;
        Current = current;
    }

    public int Get(int value)
    {
        if (Current >= value)
        {
            Current -= value;
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
    }

    public bool IsEmpty()
    {
        return Current <= 0;
    }
}
