class ModifyPropertyEffect : Effect
{
    public ModifyPropertyEffect(Modifier Modifier) : base(Modifier)
    {
    }

    protected override void ExecuteProcess()
    {
        Modifier modifier = (Modifier)Value;
        modifier.Modify(this);
    }

    public override Effect Bind(Model model)
    {
        Effect effect = new ModifyPropertyEffect((Modifier) Value)
        {
            TargetModel = model
        };
        effect.Trigger = Trigger;
        return effect;
    }
}

