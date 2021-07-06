public class PropertyPreset
{
    public enum Preset
    {
        CommonPropertySet,
        GameObjectPropertySet,
        Vector,
        Coordinate,
        RelativeCoordinate,
        CombatProperty,
        Damage,
        Armor,
        MountArray,
        Mount,
    }

    public static object GetProperty(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.CommonPropertySet: return GetCommonPropertySet(properties);
            case Preset.GameObjectPropertySet: return GetGameObjectPropertySet(properties);
            case Preset.Vector: return GetVectorProperty(properties);
            case Preset.Coordinate: return GetCoordinateProperty(properties);
            case Preset.RelativeCoordinate: return GetRelativeCoordinateProperty(properties);
            case Preset.Mount: return GetMountPointProperty(properties);
        };
        return null;
    }

    public static CommonPropertySet GetGameObjectPropertySet(object[] properties)
    {
        return new CommonPropertySet(
                (Coordinate)properties[0] //Coordinate
            );
    }

    public static CommonPropertySet GetCommonPropertySet(object[] properties)
    {
        return new CommonPropertySet(
                (Coordinate)properties[0] //Coordinate
            );
    }


    public static MountPoint GetMountPointProperty(object[] properties)
    {
        MountPoint mountPoint = new MountPoint((string)properties[0], (Coordinate)properties[1]);
        if (properties.Length == 3)
        {
            mountPoint.Mount((Model)properties[2]);
        }
        return mountPoint;
    }

    public static Coordinate.Vector GetVectorProperty(object[] properties)
    {
        return (Coordinate.Vector)properties[0];
    }

    public static Coordinate GetCoordinateProperty(object[] properties)
    {
        return new Coordinate((float)properties[0], (float)properties[1], (float)properties[2]);
    }

    public static Coordinate GetRelativeCoordinateProperty(object[] properties)
    {
        return CoordinateUtil.GetCoordinate((Coordinate)properties[0], (Coordinate.Vector)properties[1], (int)properties[2]);
    }
}
