public class EffectPreset
{
    public enum Preset
    {
        Move,
        Request,
        Chain,
        Spawn,
        Collision,
    }

    public static Effect GetEffect(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Move: return GetMoveEffect(properties);
            case Preset.Request: return GetRequestEffect(properties);
            case Preset.Chain: return GetChainEffect(properties);
            case Preset.Spawn: return GetSpawnEffect(properties);
            case Preset.Collision: return GetCollisionEffect(properties);
        };
        return null;
    }

    public static Effect GetMoveEffect(object[] properties)
    {
        if (properties[1] is Model)
        {
            return new MoveEffect((Model)properties[0], (Model)properties[1], (Coordinate)properties[2], (int)properties[3]);
        }
        else
        {
            return new MoveEffect((Model)properties[0], (Coordinate)properties[1], (Coordinate)properties[2], (int)properties[3]);
        }
    }

    public static Effect GetRequestEffect(object[] properties)
    {
        return new RequestEffect((Model)properties[0], (Storage)properties[1], (int)properties[2], (int)properties[3]);
    }

    public static Effect GetChainEffect(object[] properties)
    {
        if (properties.Length == 3)
        {
            return new ChainEffect((Model)properties[0], (Effect)properties[1], (Effect.EffectStatus)properties[2]);
        }
        return new ChainEffect((Model)properties[0], (Effect)properties[1], (Effect)properties[2], (Effect.EffectStatus)properties[3]);
    }

    public static Effect GetSpawnEffect(object[] properties)
    {
        return new SpawnEffect((Model)properties[0], (Model)properties[1], (int)properties[2]);
    }

    public static Effect GetCollisionEffect(object[] properties)
    {
        return new CollisionEffect((Model)properties[0], (Coordinate)properties[1], (int)properties[2]);
    }
}
