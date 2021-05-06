public class ChainTrigger : Trigger
{
    public const string TYPE = "chain";
    private readonly ChainSet Chain;

    public ChainTrigger(Model source, ChainSet chainSet)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, null, chainSet.HeadTrigger.OffSet)
    {
        Chain = chainSet;
    }

    public override void Hook(BattleHandler battleHandler, Model model)
    {
        Trigger Head = Chain.HeadTrigger;
        Head.Hook(battleHandler, model);
        switch (Chain.Type)
        {
            case ChainSet.ChainType.Hook:
                if (Head.HookedModel.Contains(model))
                {
                    HandleTailTrigger(battleHandler, model);
                }
                break;
            case ChainSet.ChainType.NotHook:
                if (!Head.HookedModel.Contains(model))
                {
                    HandleTailTrigger(battleHandler, model);
                }
                break;
            case ChainSet.ChainType.Always:
                HandleTailTrigger(battleHandler, model);
                break;
        }
    }

    private void HandleTailTrigger(BattleHandler battleHandler, Model model)
    {
        HookedModel.Add(model);
        battleHandler.AddTrigger(Chain.TailTrigger);
    }

    public class ChainSet
    {
        public Trigger HeadTrigger { get; }
        public Trigger TailTrigger { get; set; }
        public ChainType Type { get; }

        public ChainSet(Trigger headTrigger, Trigger tailTrigger, ChainType type)
        {
            HeadTrigger = headTrigger;
            TailTrigger = tailTrigger;
            Type = type;
        }

        public enum ChainType
        {
            Hook,
            NotHook,
            Always,
        }
    }
}
