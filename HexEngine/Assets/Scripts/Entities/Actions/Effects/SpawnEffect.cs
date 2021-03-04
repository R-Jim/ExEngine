public class SpawnEffect : Effect
{
    public SpawnEffect(Model spawnModel) : base(spawnModel)
    {
    }

    protected override void ExecuteProcess()
    {
        ModelContainer.SpawnNewModel((Model)Value);
        Status = EffectStatus.Executed;
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
