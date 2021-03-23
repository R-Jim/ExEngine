public class PropertyPreset
{
    public enum Preset
    {
        Vector,
        Coordinate,
        Damage,
        Armor,
    }

    public static object GetProperty(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Vector: return GetVectorProperty(properties);
            case Preset.Coordinate: return GetCoordinateProperty(properties);
            case Preset.Damage: return GetDamgeProperty(properties);
            case Preset.Armor: return GetArmorProperty(properties);
        };
        return null;
    }


    public static Coordinate.Vector GetVectorProperty(object[] properties)
    {
        return (Coordinate.Vector)properties[0];
    }


    public static Coordinate GetCoordinateProperty(object[] properties)
    {
        return CoordinateUtil.GetCoordinate((Coordinate)properties[0], (Coordinate.Vector)properties[1], (int)properties[2]);
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
