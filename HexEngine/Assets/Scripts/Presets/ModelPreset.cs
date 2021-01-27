public class ModelPreset
{
    public enum Preset
    {
        Model,
        Storage,
    }

    public static Model GetModel(Preset preset, params object[] properties)
    {
        switch (preset)
        {
            case Preset.Model: return GetModel(properties);
            case Preset.Storage: return GetStorageModel(properties);
        };
        return null;
    }

    private static Model GetModel(object[] properties)
    {
        return new Model(
            new CommonPropertySet(
                (int)properties[0],
                (int)properties[1],
                (Coordinate)properties[2],
                (string)properties[3],
                new MomentumPropertySet((int)properties[4], (int)properties[5], (int)properties[6]))
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[7]));
    }

    private static Model GetStorageModel(object[] properties)
    {
        return new StorageModel(
            (int)properties[0]
            , new CommonPropertySet(
                (int)properties[1],
                (int)properties[2],
                (Coordinate)properties[3],
                (string)properties[4],
                new MomentumPropertySet((int)properties[5], (int)properties[6], (int)properties[7]))
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[8]));
    }
}
