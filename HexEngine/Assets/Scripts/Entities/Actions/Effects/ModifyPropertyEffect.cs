class ModifyPropertyEffect : Effect
{
    public ModifyPropertyEffect(Modifier Modifier) : base(Modifier)
    {
    }

    protected override void ExecuteProcess()
    {
        Modifier modifier = (Modifier)Value;
        modifier.Modify(this);
    }

    public override Effect Bind(Model model)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        HookModel(upMostModel);

        Effect effect = new ModifyPropertyEffect((Modifier)Value)
        {
            TargetModel = upMostModel
        };
        effect.Trigger = Trigger;
        return effect;
    }

    private void HookModel(Model model)
    {
        Trigger.HookedModel.Add(model);
        if (model.MountPoints == null)
        {
            return;
        }
        foreach (MountPoint mountPoint in model.MountPoints)
        {
            if (mountPoint.MountedModel != null)
            {
                HookModel(mountPoint.MountedModel);
            }
        }
    }
}

