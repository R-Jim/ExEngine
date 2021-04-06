public class SpawnEffect : Effect
{
    public SpawnEffect(Model spawnModel) : base(spawnModel)
    {
    }

    protected override void ExecuteProcess()
    {
        Model model = (Model)Value;
        SpawnModel(model);
        Status = EffectStatus.Executed;
    }

    private void SpawnModel(Model model)
    {
        ModelContainer.SpawnNewModel(model);
        if (model.MountPoints != null && model.MountPoints.Length != 0)
        {
            foreach (MountPoint mountPoint in model.MountPoints)
            {
                if (mountPoint.MountedModel != null)
                {
                    SpawnModel(mountPoint.MountedModel);
                }
            }
        }
    }

    public override Effect Bind(Model model)
    {
        return new SpawnEffect((Model)Value)
        {
            TargetModel = model,
            Trigger = Trigger
        };
    }
}
