using UnityEngine;

public class PrefabPreset
{
    public enum Preset
    {
        Placeholder,
        Cannon,
        Projectile,
        Dummy,
    }

    public static GameObject GetPrefab(Preset prefabPreset)
    {
        switch (prefabPreset)
        {
            case Preset.Placeholder: return ModelContainer.PlaceholderPrefab;
            case Preset.Cannon: return null;
            case Preset.Projectile: return ModelContainer.ProjectilePrefab;
            case Preset.Dummy: return ModelContainer.DummyPrefab;
            default: return null;
        }
    }
}
