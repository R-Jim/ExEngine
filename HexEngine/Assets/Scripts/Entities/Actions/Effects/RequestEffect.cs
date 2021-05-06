public class RequestEffect : Effect
{
    public int RequireValue { get; }
    public RequestEffect(int requireValue) : base()
    {
        RequireValue = requireValue;
    }


    protected override void Process(BattleHandler battleHandler, Model targetModel)
    {
        StoragePropertySet storagePropertySet = ((StorageModel)targetModel).StoragePropertySet;
        if (storagePropertySet.Get(RequireValue) != 0)
        {
            storagePropertySet.Fill(-RequireValue);
        }
    }
}
