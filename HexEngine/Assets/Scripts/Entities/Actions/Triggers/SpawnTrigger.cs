public class SpawnTrigger : Trigger
{
    public const string TYPE = "spawn";

    public SpawnTrigger(Model source, ModelDatatable spawnedModelDatatable, Coordinate spawnCoordinate, int offset)
        : base(source, TYPE, spawnCoordinate, new SpawnEffect(spawnedModelDatatable), offset)
    {
    }


    public override void Hook(BattleHandler battleHandler, Model model)
    {
        string mountType = model.ModelDatatable.Type;
        if ("system".Equals(mountType))
        {
            HandleHookedModel(battleHandler, model);
        }
    }
}
