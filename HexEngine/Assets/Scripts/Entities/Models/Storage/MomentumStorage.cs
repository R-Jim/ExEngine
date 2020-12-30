public class MomentumStorage : Storage
{
    public Axis AxisMomentum;

    public MomentumStorage(Axis axis, int currentMomentum) : this(axis, currentMomentum, null)
    {
    }


    public MomentumStorage(Axis axis, int currentMomentum, CommonPropertySet commonPropertySet) : base(100, currentMomentum, commonPropertySet)
    {
        AxisMomentum = axis;
    }

    public enum Axis
    {
        XY,
        YX,
        XZ,
        ZX,
        YZ,
        ZY,
    }
}
