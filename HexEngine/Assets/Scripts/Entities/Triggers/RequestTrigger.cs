public class RequestTrigger : Trigger
{
    public static bool IsTriggered(StorageModel storage, int requireValue)
    {
        return storage.StoragePropertySet.Get(requireValue) > 0;
    }

    public const string TYPE = "request";

    public RequestTrigger(StorageModel source, int requireValue, int offset)
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
        return ((StorageModel)Source).StoragePropertySet.Get((int)BaseEffect.Value) != 0;
    }
}
