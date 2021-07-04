public class RequestTrigger : Trigger
{
    public const string TYPE = "request";
    public int Value { get; }

    public RequestTrigger(StorageModel source, int value, Effect effect, int offset)
        : base(source, TYPE, source.CommonPropertySet.Coordinate, effect, offset)
    {
        Value = value;
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
        StorageModel storageModel = (StorageModel)Source;
        return storageModel.StoragePropertySet.ClaimValue(Value);
    }
}
