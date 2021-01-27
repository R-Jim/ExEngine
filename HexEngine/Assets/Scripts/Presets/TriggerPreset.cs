public class TriggerPreset
{
    public enum Preset
    {
        Placeholder,
        Chain,
        Collision,
        Move,
        Request,
        Spawn,
        Target,
    }

    public static Trigger GetTrigger(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Placeholder: return GetPlaceholderTrigger();
            case Preset.Chain: return GetChainTrigger(properties);
            case Preset.Collision: return GetCollisionTrigger(properties);
            case Preset.Move: return GetMoveTrigger(properties);
            case Preset.Request: return GetRequestTrigger(properties);
            case Preset.Spawn: return GetSpawnTrigger(properties);
            case Preset.Target: return GetTargetTrigger(properties);
        };
        return null;
    }

    public static Trigger GetPlaceholderTrigger()
    {
        return new Trigger();
    }

    public static Trigger GetMoveTrigger(object[] properties)
    {
        return new MoveTrigger((Model)properties[0], (Coordinate)properties[1], (Coordinate)properties[2], (int)properties[3]);
    }

    public static Trigger GetRequestTrigger(object[] properties)
    {
        return new RequestTrigger((StorageModel)properties[0], (int)properties[1], (int)properties[2]);
    }

    public static Trigger GetChainTrigger(object[] properties)
    {
        ChainTrigger.ChainSet chainSet = new ChainTrigger.ChainSet(
                (Trigger)properties[1],
                properties[2] != null ? (Trigger)properties[2] : GetPlaceholderTrigger(),
                (ChainTrigger.ChainSet.ChainType)properties[3]
            );
        if (properties.Length == 5)
        {
            return new ChainTrigger((Model)properties[0], chainSet, (bool)properties[4]);
        }
        return new ChainTrigger((Model)properties[0], chainSet);
    }

    public static Trigger GetSpawnTrigger(object[] properties)
    {
        return new SpawnTrigger((Model)properties[0], (Model)properties[1], (int)properties[2]);
    }

    public static Trigger GetCollisionTrigger(object[] properties)
    {
        return new CollisionTrigger((Model)properties[0], (Coordinate)properties[1], (int)properties[2], (int)properties[3]);
    }

    public static Trigger GetTargetTrigger(object[] properties)
    {
        return new TargetTrigger((Model)properties[0], (Model)properties[1], (Effect)properties[2], (int)properties[3]);
    }
}
