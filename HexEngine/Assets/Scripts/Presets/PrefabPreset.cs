using UnityEngine;

public class PrefabPreset
{
    public enum Preset
    {
        Placeholder,
        Cannon,
        Projectile,
        Dummy,
        Alie,
    }

    public static GameObject GetPrefab(Preset prefabPreset)
    {
        switch (prefabPreset)
        {
            case Preset.Placeholder: return PrefabGameObjectPreset.PlaceholderPrefab;
            case Preset.Cannon: return null;
            case Preset.Projectile: return PrefabGameObjectPreset.ProjectilePrefab;
            case Preset.Dummy: return PrefabGameObjectPreset.DummyPrefab;
            default: return null;
        }
    }
}
