public class RequestEffect : Effect
{
    public RequestEffect(int requireValue) : base(requireValue)
    {

    }

    public override Effect Bind(Model model)
    {
        return new RequestEffect((int)Value)
        {
            TargetModel = model,
            Trigger = Trigger,
        };
    }

    protected override void ExecuteProcess()
    {
        StoragePropertySet storagePropertySet = ((StorageModel)TargetModel).StoragePropertySet;
        if (storagePropertySet.Get((int)Value) != 0)
        {
            storagePropertySet.Fill(-(int)Value);
            Status = EffectStatus.Executed;
        }
    }
}
