public class Storage : Model
{
    public int Max { get; }
    public int Current { get; private set; }

    public Storage(int max) : this(max, max)
    {

    }

    public Storage(int max, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : this(max, max, commonPropertySet, gameObjectPropertySet)
    {

    }

    public Storage(int max, int current) : this(max, current, null, null)
    {

    }

    public Storage(int max, int current, CommonPropertySet commonPropertySet, GameObjectPropertySet gameObjectPropertySet) : base(commonPropertySet, gameObjectPropertySet)
    {
        Max = max;
        Current = current;
    }

    public override bool IsRemovable()
    {
        return CommonPropertySet.HpStorage.IsEmpty();
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
