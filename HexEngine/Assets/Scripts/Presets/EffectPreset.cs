public class EffectPreset
{
    public enum Preset
    {
        Spawn,
        Modifier,
    }

    public static Effect GetEffect(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Spawn: return GetSpawnEffect(properties);
            case Preset.Modifier: return GetModifierEffect(properties);
        };
        return null;
    }

    public static Effect GetModifierEffect(object[] properties)
    {

        return new ModifyPropertyEffect(ModifierPreset.GetModifier((ModifierPreset.Preset)properties[0], 1, properties));
    }

    public static Effect GetSpawnEffect(object[] properties)
    {
        return new SpawnEffect((ModelDatatable)properties[0]);
    }
}
