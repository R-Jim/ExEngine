public class SpawnEffect : Effect
{
    public SpawnEffect(Model spawnModel) : base(spawnModel)
    {
    }

    protected override void ExecuteProcess(BattleHandler battleHandler)
    {
        Model model = (Model)Value;
        SpawnModel(model, battleHandler);
        Status = EffectStatus.Executed;
    }

    private void SpawnModel(Model model, BattleHandler battleHandler)
    {
        battleHandler.SpawnNewModel(model);
        if (model.MountPoints != null && model.MountPoints.Length != 0)
        {
            foreach (MountPoint mountPoint in model.MountPoints)
            {
                if (mountPoint.MountedModel != null)
                {
                    SpawnModel(mountPoint.MountedModel, battleHandler);
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
