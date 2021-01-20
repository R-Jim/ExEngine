public class RequestTrigger : Trigger
{
    public static bool IsTriggered(Storage storage, int requireValue)
    {
        return storage.Get(requireValue) > 0;
    }

    public const string TYPE = "request";

    public RequestTrigger(Storage source, int requireValue, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, offset)
    {
        BaseEffect = new RequestEffect(this, requireValue);
    }


    public override Effect Hook(Model model)
    {
        if (IsSameHashCode(model) && IsStorageHasValue())
        {
            return BaseEffect.Bind(model);
        }
        return null;
    }

    private bool IsSameHashCode(Model model)
    {
        return model.GetHashCode().Equals(Source.GetHashCode());
    }

    private bool IsStorageHasValue()
    {
        return ((Storage)Source).Get((int)BaseEffect.Value) != 0;
    }
}
