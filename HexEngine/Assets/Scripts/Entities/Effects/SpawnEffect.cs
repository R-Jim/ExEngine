public class SpawnEffect : Effect
{
    public SpawnEffect(Trigger trigger, Model spawnModel) : base(trigger, spawnModel)
    {
    }

    public override void Execute()
    {
        ModelObserver.SpawnNewModel((Model)Value);
        Status = EffectStatus.Executed;
        AssignEffectAfterExecuted();
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
