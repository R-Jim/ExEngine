public class CommonPropertySet
{
    public StoragePropertySet HpStorage;
    public Coordinate Coordinate { get; }
    public string MountType { get; }
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet;
    public int Weight { get; }

    public CommonPropertySet(int hpMax, Coordinate coordinate, int weight) : this(hpMax, hpMax, coordinate, weight, null, new MomentumPropertySet())
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, int weight, MomentumPropertySet momentumPropertySet) : this(hpMax, hpMax, coordinate, weight, null, momentumPropertySet)
    {

    }

    public CommonPropertySet(int hpMax, Coordinate coordinate, int weight, string mountType) : this(hpMax, hpMax, coordinate, weight, mountType)
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, int weight, string mountType) : this(hpMax, hpCurrent, coordinate, weight, mountType, new MomentumPropertySet())
    {

    }

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, int weight, string mountType, MomentumPropertySet momentumPropertySet)
    {
        HpStorage = new StoragePropertySet(hpMax, hpCurrent);
        Coordinate = coordinate;
        Weight = weight;
        MountType = mountType;
        MomentumPropertySet = momentumPropertySet;
    }
}
