public class RequestTrigger : Trigger
{
    public const string TYPE = "request";

    public RequestTrigger(StorageModel source, string requestType, int value, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, new RequestEffect(requestType, value), offset)
    {
    }

    public override void Hook(BattleHandler battleHandler, Model model)
    {
        if (IsSameHashCode(model) && IsStorageHasValue())
        {
            HandleHookedModel(battleHandler, model);
        }
    }

    private bool IsSameHashCode(Model model)
    {
        return model.GetHashCode().Equals(Source.GetHashCode());
    }

    private bool IsStorageHasValue()
    {
        RequestEffect requestEffect = (RequestEffect)Effect;
        return ((StorageModel)Source).StoragePropertySet.Get(requestEffect.Value) != 0;
    }
}
