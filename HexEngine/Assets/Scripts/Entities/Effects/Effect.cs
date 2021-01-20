public class Effect
{
    public EffectStatus Status { get; protected set; }
    public object Value;
    public Trigger Trigger { get; }
    public Model TargetModel { get; set; }

    public Effect(Trigger trigger, object value)
    {
        Trigger = trigger;
        Value = value;
        Status = EffectStatus.Base;
    }

    private Effect(Effect effect, Model targetModel)
    {
        Trigger = effect.Trigger;
        Value = effect.Value;
        TargetModel = targetModel;
        Status = EffectStatus.Pending;
    }

    public virtual void Execute()
    {
        Status = EffectStatus.Executed;
        AssignEffectAfterExecuted();
    }

    public void AssignEffectAfterExecuted()
    {
        Model source = Trigger.Source;
        if (source != null)
        {
            source.SourceExecutedEffect.Enqueue(this);
        }
        TargetModel.TargetExecutedEffect.Enqueue(this);
    }

    public virtual Effect Bind(Model model)
    {
        return new Effect(this, model);
    }

    public enum EffectStatus
    {
        Base,
        Pending,
        Executed,
    }
}