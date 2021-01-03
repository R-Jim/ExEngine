public class AnimationTransition
{
    public string[] Tags{ get; }
    public int Value { get; }
    public int Tick { get; }

    public AnimationTransition(string[] tags, int value, int tick)
    {
        Tags = tags;
        Value = value;
        Tick = tick;
    }
}
