public class CommonPropertySet
{
    public int Hp;
    public VectorBasedIntPropertySet ArmorValuePropertySet;
    public VectorBasedIntPropertySet DamageValuePropertySet;
    public Coordinate Coordinate;
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet { get; }
    public Coordinate.Vector FacingDirection;

    public CommonPropertySet(Coordinate coordinate)
    {
        Hp = 1;
        Coordinate = coordinate;
        ArmorValuePropertySet = new VectorBasedIntPropertySet();
        DamageValuePropertySet = new VectorBasedIntPropertySet();
        MomentumPropertySet = new MomentumPropertySet();
        FacingDirection = Coordinate.Vector.XY;
    }
}
