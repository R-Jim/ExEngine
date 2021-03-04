public class CommonPropertySet
{
    public StoragePropertySet HpStorage;
    public Coordinate Coordinate { get; }
    public string MountType { get; }
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet;
    public int Weight { get; }
    public MomentumAxisSet SpeedAxisSet;

    public CommonPropertySet(int hpMax, int hpCurrent, Coordinate coordinate, int weight, string mountType, MomentumPropertySet momentumPropertySet)
    {
        HpStorage = new StoragePropertySet(hpMax, hpCurrent);
        Coordinate = coordinate;
        Weight = weight;
        MountType = mountType;
        MomentumPropertySet = momentumPropertySet;
    }
}
