public class RequestEffect : Effect
{
    public RequestEffect(int requireValue) : base(requireValue)
    {

    }

    public override Effect Bind(Model model)
    {
        Effect effect = new RequestEffect((int)Value)
        {
            TargetModel = model
        };
        effect.Trigger = Trigger;
        return effect;
    }
}
