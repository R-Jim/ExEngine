using System.Collections.Generic;

public class StorageModelDatatable : ModelDatatable
{
    public int Max { get; }

    public StorageModelDatatable(int max, string name, string description, string type, int weight, DataSet[] properties, ActionSet[] actionSets) : base(name, description, type, weight, properties, actionSets)
    {
        Max = max;
    }

    public new Model GetModel()
    {
        CommonPropertySet commonPropertySet = (CommonPropertySet)GetDataValue(new object[] { }, COMMON_PROPERTY_INDEX);
        GameObjectPropertySet gameObjectPropertySet = (GameObjectPropertySet)GetDataValue(new object[] { }, GAMEOBJECT_PROPERTY_INDEX);
        List<MountPoint> MountPointList = new List<MountPoint>();
        for (int i = MOUNTPOINT_START_INDEX; i < DataSets.Length; i++)
        {
            MountPointList.Add((MountPoint)GetDataValue(new object[] { }, i));
        }

        return new StorageModel(Max, commonPropertySet, gameObjectPropertySet, MountPointList.ToArray());
    }
}
