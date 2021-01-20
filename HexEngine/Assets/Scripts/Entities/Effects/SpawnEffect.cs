public class SpawnEffect : Effect
{
    public SpawnEffect(Trigger trigger, Model spawnModel) : base(trigger, spawnModel)
    {
    }

    protected override void ExecuteProcess()
    {
        ModelObserver.SpawnNewModel((Model)Value);
    }

    public override Effect Bind(Model model)
    {
        Effect effect = new SpawnEffect(Trigger, (Model)Value)
        {
            TargetModel = model
        };
        return effect;
    }
}
