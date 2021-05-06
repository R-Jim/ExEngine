class ModifyPropertyEffect : Effect
{
    public Modifier Modifier { get; }

    public ModifyPropertyEffect(Modifier modifier) : base()
    {
        Modifier = modifier;
    }

    protected override void Process(BattleHandler battleHandler, Model targetModel)
    {
        Modifier.Modify(battleHandler, targetModel);
    }
}

