public class PropertyPreset
{
    public enum Preset
    {
        CommonPropertySet,
        Vector,
        Coordinate,
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
            case Preset.Vector: return GetVectorProperty(properties);
            case Preset.Coordinate: return GetCoordinateProperty(properties);
            case Preset.Mount: return GetMountPointProperty(properties);
        };
        return null;
    }

    public static CommonPropertySet GetCommonPropertySet(object[] properties)
    {
        return new CommonPropertySet(
                (Coordinate)properties[0] //Coordinate
            );
    }


    public static MountPoint GetMountPointProperty(object[] properties)
    {
        MountPoint mountPoint = new MountPoint(properties[0] != null ? (Model)properties[0] : null, (string)properties[1], (Coordinate)properties[2]);
        if (properties.Length == 4)
        {
            mountPoint.Mount((Model)properties[3]);
        }
        return mountPoint;
    }

    public static Coordinate.Vector GetVectorProperty(object[] properties)
    {
        return (Coordinate.Vector)properties[0];
    }

    public static Coordinate GetCoordinateProperty(object[] properties)
    {
        return CoordinateUtil.GetCoordinate((Coordinate)properties[0], (Coordinate.Vector)properties[1], (int)properties[2]);
    }
}
