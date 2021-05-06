public class SpawnTrigger : Trigger
{
    public const string TYPE = "spawn";

    public SpawnTrigger(Model source, Model spawnModel, int offset)
        : base(source, TYPE, spawnModel.CommonPropertySet.Coordinate, new SpawnEffect(spawnModel), offset)
    {
    }


    public override void Hook(BattleHandler battleHandler, Model model)
    {
        string mountType = model.CommonPropertySet.MountType;
        if ("system".Equals(mountType))
        {
            HandleHookedModel(battleHandler, model);
        }
    }
}
