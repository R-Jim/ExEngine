public class ModelPreset
{
    public enum Preset
    {
        Placeholder,
        Storage,
    }

    public static Model GetModel(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Placeholder: return GetPlaceholderModel(properties);
            case Preset.Storage: return GetStorageModel(properties);
        };
        return null;
    }

    private static Model GetPlaceholderModel(object[] properties)
    {
        return new Model(new CommonPropertySet((int)properties[0], (Coordinate)properties[1], (string)properties[2])
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[3])
            , (MountPoint[])properties[4]);
    }

    private static Model GetStorageModel(object[] properties)
    {
        return new Storage((int)properties[0]
            , new CommonPropertySet((int)properties[1], (Coordinate)properties[2], (string)properties[3])
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[4]));
    }
}
