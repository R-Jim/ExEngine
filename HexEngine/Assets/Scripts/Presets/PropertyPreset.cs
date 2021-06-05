using System.Collections.Generic;
using System.Linq;

public class PropertyPreset
{
    public enum Preset
    {
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
            case Preset.Vector: return GetVectorProperty(properties);
            case Preset.Coordinate: return GetCoordinateProperty(properties);
            case Preset.CombatProperty: return GetCombatProperty(properties);
            case Preset.Damage: return GetDamgeProperty(properties);
            case Preset.Armor: return GetArmorProperty(properties);
            case Preset.MountArray: return GetMountPointArrayProperty(properties);
            case Preset.Mount: return GetMountPointProperty(properties);
        };
        return null;
    }

    public static MountPoint[] GetMountPointArrayProperty(object[] properties)
    {
        return properties.Select(property => (MountPoint)property).ToArray();
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

    public static CombatPropertySet GetCombatProperty(object[] properties)
    {
        List<DamagePropertySet> DamagePropertySets = new List<DamagePropertySet>();
        List<ArmorPropertySet> ArmorPropertySets = new List<ArmorPropertySet>();
        foreach (object property in properties)
        {
            if (property is DamagePropertySet)
            {
                DamagePropertySets.Add((DamagePropertySet)property);
            }
            else
            {
                ArmorPropertySets.Add((ArmorPropertySet)property);
            }
        }
        return new CombatPropertySet(DamagePropertySets.ToArray(), ArmorPropertySets.ToArray());
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
        return new DamagePropertySet(
            (int)properties[0],     //base value
            (float)properties[1],   //Impact modifier
            (bool)properties[2]     //Is true damage
            );
    }

    public static ArmorPropertySet GetArmorProperty(object[] properties)
    {
        return new ArmorPropertySet(
            (int)properties[0],   //value
            (float)properties[1], //Nullify modifier
            (int)properties[2]    //Absorbtion value
            );
    }
}
