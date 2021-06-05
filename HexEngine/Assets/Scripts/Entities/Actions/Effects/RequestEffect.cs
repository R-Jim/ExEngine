public class RequestEffect : Effect
{
    public int Value { get; }
    public string RequestType { get; }
    public RequestEffect(string requestType, int value) : base()
    {
        Value = value;
        RequestType = requestType;
    }


    protected override void Process(BattleHandler battleHandler, Model targetModel)
    {
        StoragePropertySet storagePropertySet = ((StorageModel)targetModel).StoragePropertySet;
        if (storagePropertySet.Get(Value) != 0)
        {
            storagePropertySet.Fill(-Value);
        }
    }
}
