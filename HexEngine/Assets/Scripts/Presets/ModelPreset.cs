public class ModelPreset
{
    public enum Preset
    {
        Storage,
    }

    public static Model GetModel(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Storage: return GetStorageModel(properties);
        };
        return null;
    }

    private static Model GetStorageModel(object[] properties)
    {
        return new Storage((int)properties[0]
            , new CommonPropertySet((int)properties[1], (Coordinate)properties[2])
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[3]));
    }
}
