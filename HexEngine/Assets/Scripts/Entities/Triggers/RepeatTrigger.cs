public class RepeatTrigger
{
    public static bool IsTriggered(RepeatEffect.RepeaterProperties repeaterProperties, IRepeater repeater)
    {
        return repeaterProperties.IsMatchTickRate(0) && repeater.CanRepeat();
    }
}
