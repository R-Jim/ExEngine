public class CommonPropertySet
{
    public int HpMax { get; }
    public int HpCurrent;
    public Coordinate Coordinate { get; }
	public string Type { get; }
    public MountPoint MountedTo;

    public CommonPropertySet(int hpMax, Coordinate coordinate) : this(hpMax, hpMax, coordinate, null)
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, string type) : this(hpMax, hpMax, coordinate, type)
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, string type)
    {
        HpMax = hpMax;
        HpCurrent = hpCurrent;
        Coordinate = coordinate;
        Type = type;
    }
}
