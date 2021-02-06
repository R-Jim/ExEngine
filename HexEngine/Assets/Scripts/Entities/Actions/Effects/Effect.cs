public class Effect
{
    public EffectStatus Status { get; protected set; }
    public object Value;
    public Trigger Trigger;
    public Model TargetModel;

    public Effect(object value)
    {
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

    public void Execute()
    {
        ExecuteProcess();
        PostExecute();
    }

    protected virtual void ExecuteProcess()
    {

    }

    protected virtual void PostExecute()
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
        Trigger.HookedModel.Add(model);
        return new Effect(this, model);
    }

    public enum EffectStatus
    {
        Base,
        Pending,
        Executed,
    }
}