public class CombatPreset
{
    public enum Preset
    {
        Damage,
        Armor,
    }

    public static object GetCombatProperty(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Damage: return GetDamgeProperty(properties);
            case Preset.Armor: return GetArmorProperty(properties);
        };
        return null;
    }

    public static DamagePropertySet GetDamgeProperty(object[] properties)
    {
        return new DamagePropertySet((int)properties[0], (float)properties[1], (bool)properties[2]);
    }

    public static ArmorPropertySet GetArmorProperty(object[] properties)
    {
        return new ArmorPropertySet((float)properties[0], (int)properties[1]);
    }
}
