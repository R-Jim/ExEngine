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
                (int)properties[3],
                (string)properties[4],
                new MomentumPropertySet((int)properties[5], (int)properties[6], (int)properties[7]))
            , properties[8] != null ? (CombatPropertySet)properties[8] : null
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[9])
            , null
            );
    }

    private static Model GetStorageModel(object[] properties)
    {
        return new StorageModel(
            (int)properties[0]
            , (int)properties[0]
            , new CommonPropertySet(
                (int)properties[1],
                (int)properties[2],
                (Coordinate)properties[3],
                (int)properties[4],
                (string)properties[5],
                new MomentumPropertySet((int)properties[6], (int)properties[7], (int)properties[8]))
            , properties[9] != null ? (CombatPropertySet)properties[9] : null
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[10]));
    }
}
