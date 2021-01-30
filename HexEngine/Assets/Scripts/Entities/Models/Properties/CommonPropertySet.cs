public class CommonPropertySet
{
    public StoragePropertySet HpStorage;
    public Coordinate Coordinate { get; }
    public string MountType { get; }
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet;

    public CommonPropertySet(int hpMax, Coordinate coordinate) : this(hpMax, hpMax, coordinate, null, new MomentumPropertySet())
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, MomentumPropertySet momentumPropertySet) : this(hpMax, hpMax, coordinate, null, momentumPropertySet)
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, string mountType) : this(hpMax, hpMax, coordinate, mountType)
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, string mountType) : this(hpMax, hpCurrent, coordinate, mountType, new MomentumPropertySet())
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, string mountType, MomentumPropertySet momentumPropertySet)
    {
        HpStorage = new StoragePropertySet(hpMax, hpCurrent);
        Coordinate = coordinate;
        MountType = mountType;
        MomentumPropertySet = momentumPropertySet;
    }
}
