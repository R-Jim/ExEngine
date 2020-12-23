public class RepeatTrigger
{
    public static bool IsTriggered(IRepeater repeater)
    {
        return repeater.CanRepeat();
    }
}
