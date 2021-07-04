public class SpawnEffect : Effect
{
    private readonly ModelDatatable ModelDatatable;

    public SpawnEffect(ModelDatatable modelDatatable) : base()
    {
        ModelDatatable = modelDatatable;
    }

    protected override void Process(BattleHandler battleHandler, Model model)
    {
        SpawnModel(battleHandler);
    }

    private void SpawnModel(BattleHandler battleHandler)
    {
        Model model = ModelDatatable.GetModel();
        model.CommonPropertySet.Coordinate = Trigger.TriggerCoordinate;
        battleHandler.SpawnNewModel(model);
    }
}
