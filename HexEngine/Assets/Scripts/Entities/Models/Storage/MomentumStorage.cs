public class MomentumStorage : Storage
{
    public Axis AxisMomentum;

    public MomentumStorage(Axis axis, int currentMomentum) : base(100, currentMomentum)
    {
        AxisMomentum = axis;
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
