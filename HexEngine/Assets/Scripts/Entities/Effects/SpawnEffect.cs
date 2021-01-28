public class SpawnEffect : Effect
{
    public SpawnEffect(Model spawnModel) : base(spawnModel)
    {
    }

    protected override void ExecuteProcess()
    {
        ModelContainer.SpawnNewModel((Model)Value);
    }

    public override Effect Bind(Model model)
    {
        Effect effect = new SpawnEffect((Model)Value)
        {
            TargetModel = model
        };
        effect.Trigger = Trigger;
        return effect;
    }
}
