public class ModifierPreset
{
    public enum Preset
    {
        Coordinate,
        Hp,
        Momentum,
    }

    public static Modifier GetModifier(Preset preset, int offset = 0, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Coordinate: return GetCoordinateModifier(properties, offset);
            case Preset.Hp: return GetHpModifier(properties, offset);
            case Preset.Momentum: return GetMomentumModifier(properties, offset);
        };
        return null;
    }

    public static Modifier GetMomentumModifier(object[] properties, int offset)
    {
        return new MomentumModifier(new VectorPropertySet((Coordinate.Vector)properties[0 + offset], (int)properties[1 + offset]));
    }

    public static Modifier GetHpModifier(object[] properties, int offset)
    {
        return new HpModifier((int)properties[0 + offset]);
    }

    public static Modifier GetCoordinateModifier(object[] properties, int offset)
    {
        return new CoordinateModifier((Coordinate.Vector)properties[0 + offset]);
    }
}

