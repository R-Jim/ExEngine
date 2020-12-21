public class MomentumRepeater : IRepeater
{
    public MomentumStorage MomentumStorage { get; }

    public MomentumRepeater(MomentumStorage momentumStorage)
    {
        MomentumStorage = momentumStorage;
    }

    public bool CanRepeat()
    {
        return !MomentumStorage.IsEmpty();
    }
}
