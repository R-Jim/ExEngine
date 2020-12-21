public class RequestTrigger
{
    public static bool IsTriggered(Storage storage, int requireValue)
    {
        return storage.Get(requireValue) > 0;
    }
}
