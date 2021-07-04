public class TriggerPreset
{
    public enum Preset
    {
        Trigger,
        Chain,
        Request,
        Spawn,
        Target,
    }

    public static Trigger GetTrigger(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Trigger: return GetTrigger(properties);
            case Preset.Chain: return GetChainTrigger(properties);
            case Preset.Request: return GetRequestTrigger(properties);
            case Preset.Spawn: return GetSpawnTrigger(properties);
            case Preset.Target: return GetTargetTrigger(properties);
        };
        return null;
    }

    public static Trigger GetTrigger(object[] properties)
    {
        return new Trigger((Model)properties[0], (Coordinate)properties[1], (Effect)properties[2], (int)properties[3]);
    }

    public static Trigger GetRequestTrigger(object[] properties)
    {
        return new RequestTrigger((StorageModel)properties[0], (int)properties[1], (Effect)properties[2], (int)properties[3]);
    }

    public static Trigger GetChainTrigger(object[] properties)
    {
        ChainTrigger.ChainSet chainSet = new ChainTrigger.ChainSet(
                (Trigger)properties[1],
                properties[2] != null ? (Trigger)properties[2] : null,
                (ChainTrigger.ChainSet.ChainType)properties[3]
            );
        return new ChainTrigger((Model)properties[0], chainSet);
    }

    public static Trigger GetSpawnTrigger(object[] properties)
    {
        return new SpawnTrigger((Model)properties[0], (ModelDatatable)properties[1], (Coordinate)properties[2], (int)properties[3]);
    }

    public static Trigger GetTargetTrigger(object[] properties)
    {
        return new TargetTrigger((Model)properties[0], (Model)properties[1], (Effect)properties[2], (int)properties[3]);
    }
}
