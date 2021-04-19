public class MomentumModifier : Modifier
{
    public MomentumModifier(VectorPropertySet vectorPropertySet) : base(vectorPropertySet)
    {

    }

    public override void Modify(Effect effect, BattleHandler battleHandler)
    {
        GetMomentumPropertySet(effect.TargetModel).Add((VectorPropertySet)Value);
    }

    private MomentumPropertySet GetMomentumPropertySet(Model model)
    {
        MountPoint mountPoint = model.CommonPropertySet.MountedTo;
        if (mountPoint != null)
        {
            return GetMomentumPropertySet(mountPoint.SourceModel);
        }
        return model.CommonPropertySet.MomentumPropertySet;
    }
}
