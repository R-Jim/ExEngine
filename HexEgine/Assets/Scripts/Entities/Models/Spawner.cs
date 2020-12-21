public class Spawner : Model
{
    public int RequireValue { get; }

    public SpawnEffect GetSpawnEffect()
    {
        return new SpawnEffect(this, null, null);
    }
}
