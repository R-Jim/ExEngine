public class EffectPreset
{
    public enum Preset
    {
        Request,
        Chain,
        Spawn,
        Modifier,
    }

    public static Effect GetEffect(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Request: return GetRequestEffect(properties);
            case Preset.Chain: return GetChainEffect(properties);
            case Preset.Spawn: return GetSpawnEffect(properties);
            case Preset.Modifier: return GetModifierEffect(properties);
        };
        return null;
    }

    public static Effect GetModifierEffect(object[] properties)
    {

        return new ModifyPropertyEffect(ModifierPreset.GetModifier((ModifierPreset.Preset)properties[0], 1, properties));
    }

    public static Effect GetRequestEffect(object[] properties)
    {
        return new RequestEffect((int)properties[0]);
    }

    public static Effect GetChainEffect(object[] properties)
    {
        return new ChainEffect((ChainTrigger.ChainSet)properties[0]);
    }

    public static Effect GetSpawnEffect(object[] properties)
    {
        return new SpawnEffect((Model)properties[0]);
    }
}
