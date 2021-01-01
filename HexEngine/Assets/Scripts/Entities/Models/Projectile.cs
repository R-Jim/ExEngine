public class Projectile : Model
{
    //Project tile move range
    public MomentumStorage MomentumStorage { get; }

    public Projectile(MomentumStorage momentumStorage, CommonPropertySet commonPropertySet): base(commonPropertySet)
    {
        MomentumStorage = momentumStorage;
    }

    public override bool IsRemovable()
    {
        return CommonPropertySet.HpCurrent == 0 || MomentumStorage.IsEmpty();
    }
}
