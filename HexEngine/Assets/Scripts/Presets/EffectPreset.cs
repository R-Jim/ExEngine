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
        Trigger trigger = properties[0] != null ? (Trigger)properties[0] : new Trigger();
        return new MoveEffect(trigger, (Coordinate)properties[1]);
    }

    public static Effect GetRequestEffect(object[] properties)
    {
        Trigger trigger = properties[0] != null ? (Trigger)properties[0] : new Trigger();
        return new RequestEffect(trigger, (int)properties[1]);
    }

    public static Effect GetChainEffect(object[] properties)
    {
        Trigger trigger = properties[0] != null ? (Trigger)properties[0] : new Trigger();
        return new ChainEffect(trigger, (ChainTrigger.ChainSet)properties[1]);
    }

    public static Effect GetSpawnEffect(object[] properties)
    {
        Trigger trigger = properties[0] != null ? (Trigger)properties[0] : new Trigger();
        return new SpawnEffect(trigger, (Model)properties[1]);
    }

    public static Effect GetCollisionEffect(object[] properties)
    {
        Trigger trigger = properties[0] != null ? (Trigger)properties[0] : new Trigger();
        return new CollisionEffect(trigger, (int)properties[1]);
    }
}
