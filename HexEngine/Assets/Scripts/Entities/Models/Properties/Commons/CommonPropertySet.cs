public class CommonPropertySet
{
    public int Hp;
    public VectorBasedPropertySet ArmorValuePropertySet;
    public VectorBasedPropertySet DamageValuePropertySet;
    public Coordinate Coordinate;
    public MountPoint MountedTo;
    public MomentumPropertySet MomentumPropertySet { get; }
    public Coordinate.Vector FacingDirection;

    public CommonPropertySet(Coordinate coordinate)
    {
        Hp = 1;
        Coordinate = coordinate;
        ArmorValuePropertySet = new VectorBasedPropertySet();
        DamageValuePropertySet = new VectorBasedPropertySet();
        MomentumPropertySet = new MomentumPropertySet();
        FacingDirection = Coordinate.Vector.XY;
    }
}
