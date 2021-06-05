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
                (int)properties[0],             //Max Hp
                (int)properties[1],             //Current Hp
                (Coordinate)properties[2],      //Current position
                (int)properties[3],             //Weight    
                (string)properties[4],          //Mount type
                new MomentumPropertySet(        //Initial momentum
                    (int)properties[5],             //X
                    (int)properties[6],             //Y
                    (int)properties[7])             //Z
                ),
                properties[8] != null ? (CombatPropertySet)properties[8] : null //Combat set
                , new GameObjectPropertySet((PrefabPreset.Preset)properties[9]) //Prefab
                , properties.Length >= 11 ? (MountPoint[])properties[10] : null //Mount Points config
            );
    }

    private static Model GetStorageModel(object[] properties)
    {
        return new StorageModel(
                (int)properties[0],         //Max storage
                (int)properties[0],         //Current storage
                new CommonPropertySet(
                    (int)properties[1],         //Max Hp
                    (int)properties[2],         //Current Hp
                    (Coordinate)properties[3],  //Current position
                    (int)properties[4],         //Weight
                    (string)properties[5],      //Mount type
                    new MomentumPropertySet(    //Initial momentum
                        (int)properties[6],         //X
                        (int)properties[7],         //Y
                        (int)properties[8])         //Z
                ),
             properties[9] != null ? (CombatPropertySet)properties[9] : null    //Combat set
            , new GameObjectPropertySet((PrefabPreset.Preset)properties[10]));  //Prefab
    }
}
