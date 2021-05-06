public class SpawnEffect : Effect
{
    private readonly Model Model;

    public SpawnEffect(Model model) : base()
    {
        Model = model;
    }

    protected override void Process(BattleHandler battleHandler, Model model)
    {
        SpawnModel(Model, battleHandler);
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
}
