public class CommonPropertySet
{
    public int HpMax { get; }
    public int HpCurrent;
    public Coordinate Coordinate { get; }
    public string MountType { get; }
    public MountPoint MountedTo;

    public CommonPropertySet(int hpMax, Coordinate coordinate) : this(hpMax, hpMax, coordinate, null)
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, string mountType) : this(hpMax, hpMax, coordinate, mountType)
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, string mountType)
    {
        HpMax = hpMax;
        HpCurrent = hpCurrent;
        Coordinate = coordinate;
        MountType = mountType;
    }
}
