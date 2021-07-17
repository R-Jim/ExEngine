public class CommonPropertySet
{
    public int Hp;
    public VectorBasedIntPropertySet ArmorVectorValuePropertySet;
    public Coordinate Coordinate;
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet { get; }
    public Coordinate.Vector FacingDirection;

    public CommonPropertySet(Coordinate coordinate)
    {
        Hp = 1;
        Coordinate = coordinate;
        ArmorVectorValuePropertySet = new VectorBasedIntPropertySet();
        MomentumPropertySet = new MomentumPropertySet();
        FacingDirection = Coordinate.Vector.XY;
    }
}
