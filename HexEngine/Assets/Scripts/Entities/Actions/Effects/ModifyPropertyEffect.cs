class ModifyPropertyEffect : Effect
{
    public ModifyPropertyEffect(Modifier Modifier) : base(Modifier)
    {
    }

    protected override void ExecuteProcess(BattleHandler battleHandler)
    {
        Modifier modifier = (Modifier)Value;
        modifier.Modify(this, battleHandler);
        Status = EffectStatus.Executed;
    }

    public override Effect Bind(Model model)
    {
        Model upMostModel = CommonPropertySetUtil.GetUpMostModel(model);
        return new ModifyPropertyEffect((Modifier)Value)
        {
            TargetModel = upMostModel,
            Trigger = Trigger
        };
    }
}

