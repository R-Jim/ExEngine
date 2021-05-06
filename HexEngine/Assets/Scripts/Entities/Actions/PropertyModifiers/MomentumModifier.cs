public class MomentumModifier : Modifier
{
    public MomentumModifier(VectorPropertySet vectorPropertySet) : base(vectorPropertySet)
    {

    }

    public override void Modify(BattleHandler battleHandler, Model targetModel)
    {
        GetMomentumPropertySet(targetModel).Add((VectorPropertySet)Value);
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
