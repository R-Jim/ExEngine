public class RequestEffect : Effect
{
    public RequestEffect(Trigger trigger, int requireValue) : base(trigger, requireValue)
    {

    }

    public override Effect Bind(Model model)
    {
        Effect effect = new RequestEffect(Trigger, (int)Value)
        {
            TargetModel = model
        };
        return effect;
    }
}
