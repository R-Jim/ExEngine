public class Spawner : Model
{
    public int RequireValue { get; }

    public Spawner() : base(null)
    {

    }

    public SpawnEffect GetSpawnEffect()
    {
        return new SpawnEffect(this, null, null);
    }
}
