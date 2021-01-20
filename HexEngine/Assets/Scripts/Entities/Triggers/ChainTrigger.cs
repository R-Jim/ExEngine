public class ChainTrigger : Trigger
{
    public const string TYPE = "chain";

    public ChainTrigger(Model source, ChainSet chainSet, bool isSelfChain = false)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, chainSet.HeadTrigger.OffSet)
    {
        if (isSelfChain)
        {
            chainSet.TailTrigger = this;
        }
        BaseEffect = new ChainEffect(this, chainSet);
    }

    public override Effect Hook(Model model)
    {
        ChainSet chainSet = (ChainSet)BaseEffect.Value;

        Effect headEffect = chainSet.HeadTrigger.Hook(model);
        Effect bindedEffect = BaseEffect.Bind(model);
        switch (chainSet.Type)
        {
            case ChainSet.ChainType.Hook:
                if (headEffect != null)
                {
                    return bindedEffect;
                }
                break;
            case ChainSet.ChainType.NotHook:
                if (headEffect == null)
                {
                   return chainSet.TailTrigger.Hook(model);
                }
                break;
            case ChainSet.ChainType.Always:
                return bindedEffect;
        }
        return null;
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
