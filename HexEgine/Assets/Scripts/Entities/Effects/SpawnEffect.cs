public class SpawnEffect : Effect
{
    public const string TYPE = "spawn";

    public SpawnEffect(Model source, Coordinate coordinate, object value) : base(source, coordinate, TYPE, value)
    {
    }

    //TODO: implement rest of Spawn activate, execute functions
}
