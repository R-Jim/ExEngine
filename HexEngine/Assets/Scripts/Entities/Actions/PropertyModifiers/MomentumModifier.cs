public class MomentumModifier : Modifier
{
    public MomentumModifier(VectorPropertySet vectorPropertySet) : base(vectorPropertySet)
    {

    }

    public override void Modify(Effect effect)
    {
        Model model = effect.TargetModel;
        MomentumPropertySet momentumPropertySet = GetMomentumPropertySet(model);
        momentumPropertySet.Add((VectorPropertySet)Value);
    }

    private MomentumPropertySet GetMomentumPropertySet(Model model)
    {
        MountPoint mountPoint = model.CommonPropertySet.MountedTo;
        if (mountPoint != null)
        {
            GetMomentumPropertySet(mountPoint.SourceModel);
        }
        return model.CommonPropertySet.MomentumPropertySet;
    }
}
